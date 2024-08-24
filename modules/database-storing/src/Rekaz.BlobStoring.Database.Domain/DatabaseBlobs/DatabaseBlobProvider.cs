using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Rekaz.BlobStoring.Database.DatabaseBlobs;

public class DatabaseBlobProvider : BlobProviderBase, ITransientDependency
{
    private readonly IDatabaseBlobRepository _databaseBlobRepository;

    public DatabaseBlobProvider(IDatabaseBlobRepository databaseBlobRepository, IGuidGenerator guidGenerator)
    {
        _databaseBlobRepository = databaseBlobRepository;
    }


    public async override Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args)
    {
        var blob = await _databaseBlobRepository.FindAsync(b => b.Id == new Guid(args.BlobName));

        if (blob == null)
        {
            return null;
        }

        return new MemoryStream(blob.Content);
    }

    public async override Task SaveAsync(BlobProviderSaveArgs args)
    {
        var bolbId = new Guid(args.BlobName);
        var blob = await _databaseBlobRepository.FindAsync(b => b.Id == bolbId);

        var content = await args.BlobStream.GetAllBytesAsync(args.CancellationToken);

        if (blob != null)
        {
            throw new BlobAlreadyExistsException(
                $"Saving BLOB '{args.BlobName}' does already exists!");
        }
        blob = new DatabaseBlob(bolbId, content);
        await _databaseBlobRepository.InsertAsync(blob, autoSave: true);
    }
}