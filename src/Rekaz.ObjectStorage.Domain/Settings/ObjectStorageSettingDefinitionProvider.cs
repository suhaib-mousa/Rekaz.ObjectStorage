using Volo.Abp.Settings;

namespace Rekaz.ObjectStorage.Settings;

public class ObjectStorageSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ObjectStorageSettings.MySetting1));
    }
}
