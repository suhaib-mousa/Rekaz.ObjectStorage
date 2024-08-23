using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Rekaz.ObjectStorage.ObjectFiles;

public interface IObjectFileAppService : IApplicationService
{
    Task<ObjectFileDto> GetAsync(Guid id);
    Task StoreAsync(Guid id, string data);
}
