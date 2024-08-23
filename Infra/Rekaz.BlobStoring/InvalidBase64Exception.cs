using Volo.Abp;

namespace Rekaz.BlobStoring;

public class InvalidBase64Exception : AbpException
{
    public InvalidBase64Exception()
    {

    }

    public InvalidBase64Exception(string message)
        : base(message)
    {

    }

    public InvalidBase64Exception(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}