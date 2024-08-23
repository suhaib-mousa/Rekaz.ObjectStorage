using Rekaz.ObjectStorage.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Rekaz.ObjectStorage.Permissions;

public class ObjectStoragePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ObjectStoragePermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ObjectStoragePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ObjectStorageResource>(name);
    }
}
