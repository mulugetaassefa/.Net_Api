namespace AdvisoryApp.DataBaseSetting
{
    public class AdvisorDataBaseSettings : IAdvisorDataBaseSettings
    {

        public string AdvisorCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
