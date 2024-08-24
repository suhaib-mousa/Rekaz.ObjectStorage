using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

public class AwsS3Client
{
    private readonly string _accessKey;
    private readonly string _secretKey;
    private readonly string _region;
    private readonly string _bucket;
    private readonly HttpClient _httpClient;

    public AwsS3Client(string accessKey, string secretKey, string region, string bucket)
    {
        _accessKey = accessKey;
        _secretKey = secretKey;
        _region = region;
        _bucket = bucket;
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler);
    }

    private string GetAuthorizationHeaderV4(string httpMethod, string contentSha256, string date, string canonicalizedResource)
    {
        string dateStamp = date.Substring(0, 8);
        string credentialScope = $"{dateStamp}/{_region}/s3/aws4_request";
        string canonicalRequest = $"{httpMethod}\n{canonicalizedResource}\n\nhost:{_bucket}.s3.{_region}.amazonaws.com\nx-amz-content-sha256:{contentSha256}\nx-amz-date:{date}\n\nhost;x-amz-content-sha256;x-amz-date\n{contentSha256}";

        using var sha256 = SHA256.Create();
        string stringToSign = $"AWS4-HMAC-SHA256\n{date}\n{credentialScope}\n{BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(canonicalRequest))).Replace("-", "").ToLower()}";

        byte[] kSecret = Encoding.UTF8.GetBytes($"AWS4{_secretKey}");
        byte[] kDate = HmacSHA256(dateStamp, kSecret);
        byte[] kRegion = HmacSHA256(_region, kDate);
        byte[] kService = HmacSHA256("s3", kRegion);
        byte[] kSigning = HmacSHA256("aws4_request", kService);

        byte[] signature = HmacSHA256(stringToSign, kSigning);

        return $"AWS4-HMAC-SHA256 Credential={_accessKey}/{credentialScope}, SignedHeaders=host;x-amz-content-sha256;x-amz-date, Signature={BitConverter.ToString(signature).Replace("-", "").ToLower()}";
    }

    private static byte[] HmacSHA256(string data, byte[] key)
    {
        using var hmac = new HMACSHA256(key);
        return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
    }

    public async Task UploadStreamAsync(string key, Stream content)
    {
        try
        {
            string date = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");
            string canonicalizedResource = key.EnsureStartsWith('/');

            using var memoryStream = new MemoryStream();
            await content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            using var sha256 = SHA256.Create();
            string contentSha256 = BitConverter.ToString(sha256.ComputeHash(memoryStream)).Replace("-", "").ToLower();

            memoryStream.Position = 0;

            var request = new HttpRequestMessage(HttpMethod.Put, $"https://{_bucket}.s3.{_region}.amazonaws.com/{key}");
            request.Content = new StreamContent(memoryStream);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            request.Headers.Add("x-amz-date", date);
            request.Headers.Add("x-amz-content-sha256", contentSha256);
            request.Headers.Host = $"{_bucket}.s3.{_region}.amazonaws.com";

            string authHeader = GetAuthorizationHeaderV4("PUT", contentSha256, date, canonicalizedResource);
            var authParts = authHeader.Split(' ', 2);
            request.Headers.Authorization = new AuthenticationHeaderValue(authParts[0], authParts[1]);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"S3 request failed: {response.StatusCode}, {errorContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<Stream> DownloadStreamAsync(string key)
    {
        try
        {
            string date = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");
            string canonicalizedResource = key.EnsureStartsWith('/');
            string contentSha256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"; // empty body hash

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://{_bucket}.s3.{_region}.amazonaws.com/{key}");
            request.Headers.Add("x-amz-date", date);
            request.Headers.Add("x-amz-content-sha256", contentSha256);
            request.Headers.Host = $"{_bucket}.s3.{_region}.amazonaws.com";

            string authHeader = GetAuthorizationHeaderV4("GET", contentSha256, date, canonicalizedResource);
            var authParts = authHeader.Split(' ', 2);
            request.Headers.Authorization = new AuthenticationHeaderValue(authParts[0], authParts[1]);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"S3 request failed: {response.StatusCode}, {errorContent}");
            }

            return await response.Content.ReadAsStreamAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            throw;
        }
    }
}