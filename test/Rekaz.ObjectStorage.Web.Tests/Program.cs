using Microsoft.AspNetCore.Builder;
using Rekaz.ObjectStorage;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ObjectStorageWebTestModule>();

public partial class Program
{
}
