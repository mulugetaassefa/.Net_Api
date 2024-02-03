using AdvisoryApp.DataBaseSetting;

namespace AdvisoryApp.DataBaseSetting
{
    public class IAdminDataBaseSettings
    {
        string AdminCollectionName { get; set; } = string.Empty;
        string ConnectionString { get; set; } = string.Empty;
        string DatabaseName { get; set; } = string.Empty;
    }
}
