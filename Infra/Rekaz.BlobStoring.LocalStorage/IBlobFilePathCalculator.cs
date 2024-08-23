namespace Rekaz.BlobStoring.LocalStorage;

public interface IBlobFilePathCalculator
{
    string Calculate(BlobProviderArgs args);
}
