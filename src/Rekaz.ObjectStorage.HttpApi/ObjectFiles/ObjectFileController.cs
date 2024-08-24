using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rekaz.BlobStoring;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rekaz.ObjectStorage.ObjectFiles;

[ApiController]
[Authorize]
[Route("v1")]
public class ObjectFileController : AbpController
{
    private readonly IObjectFileAppService _objectStorageAppService;

    public ObjectFileController(IObjectFileAppService objectStorageAppService)
    {
        _objectStorageAppService = objectStorageAppService;
    }

    [HttpGet("blobs/{id}")]
    public async Task<ObjectFileDto> GetAsync(Guid id)
     => await _objectStorageAppService.GetAsync(id);

    [HttpPost("blobs")]
    public async Task<IActionResult> StoreAsync([FromBody] ObjectFileInput input)
    {
        try
        {
            await _objectStorageAppService.StoreAsync(input.Id, input.Data);
            return Ok();
        }
        catch (InvalidBase64Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }
}
