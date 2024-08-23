using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Rekaz.ObjectStorage.Pages;

[Collection(ObjectStorageTestConsts.CollectionDefinitionName)]
public class Index_Tests : ObjectStorageWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
