using Microsoft.AspNetCore.Authorization;
using Rekaz.BlobStoring;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Rekaz.ObjectStorage.ObjectFiles;

[RemoteService(false)]
[Authorize]
public class ObjectFileAppService : ApplicationService, IObjectFileAppService
{
    private readonly IRepository<ObjectFile, Guid> _repository;
    private readonly IBlobStorageService _blobStorageService;

    public ObjectFileAppService(IRepository<ObjectFile, Guid> repository, IBlobStorageService blobStorageService)
    {
        _repository = repository;
        _blobStorageService = blobStorageService;
    }
    public virtual async Task<ObjectFileDto> GetAsync(Guid id)
    {
        var objectFile = await _repository.GetAsync(id);

        using var stream = await _blobStorageService.GetAsync(id.ToString());
        if (stream == null)
        {
            throw new Exception($"Blob with ID '{id}' not found.");
        }

        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        var base64Data = Convert.ToBase64String(memoryStream.ToArray());

        return new ObjectFileDto
        {
            Id = id,
            Data = base64Data,
            Size = objectFile.Size,
            CreatedAt = objectFile.CreationTime
        };
    }

    public virtual async Task StoreAsync(Guid id, string data)
    {
        try
        {
            var bytes = Convert.FromBase64String(data);

            using var memoryStream = new MemoryStream(bytes);
            await _blobStorageService.SaveAsync(id.ToString(), memoryStream);

            var objectFile = new ObjectFile(id, bytes.Length);
            await _repository.InsertAsync(objectFile);
        }
        catch (FormatException ex)
        {
            throw new InvalidBase64Exception("The provided data is not a valid Base64 string.", ex);
        }
    }
}
