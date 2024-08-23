using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using Rekaz.BlobStoring;
using Rekaz.BlobStoring.LocalStorage;
using Rekaz.BlobStoring.Aws;

namespace Rekaz.ObjectStorage;

[DependsOn(
    typeof(ObjectStorageDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    //typeof(BlobStoringLocalStorageModule),
    typeof(BlobStoringAwsModule),
    typeof(BlobStoringModule)
)]
public class ObjectStorageApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ObjectStorageDtoExtensions.Configure();
    }
}
