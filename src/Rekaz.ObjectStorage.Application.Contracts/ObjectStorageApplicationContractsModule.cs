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
using Rekaz.BlobStoring.FTP;

namespace Rekaz.ObjectStorage;

[DependsOn(
    typeof(BlobStoringLocalStorageModule),
    //typeof(BlobStoringAwsModule),
    //typeof(BlobStoringFTPModule),
    typeof(BlobStoringModule),
    typeof(ObjectStorageDomainSharedModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class ObjectStorageApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ObjectStorageDtoExtensions.Configure();
    }
}
