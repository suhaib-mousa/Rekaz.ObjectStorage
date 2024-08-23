namespace Rekaz.BlobStoring;

public class BlobStoringOptions
{
    public BlobStoringConfiguration Configuration { get; }
    public BlobStoringOptions()
    {
        Configuration = new BlobStoringConfiguration();
    }
}
