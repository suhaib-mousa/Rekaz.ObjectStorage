namespace Rekaz.BlobStoring.Database;

public static class DatabaseDbProperties
{
    public static string DbTablePrefix { get; set; } = "DS";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Database";
}
