namespace AdvisoryApp.DataBaseSetting
{
    public class AdminDataBaseSettings : IAdminDataBaseSettings
    {
        public string AdminCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }

}
