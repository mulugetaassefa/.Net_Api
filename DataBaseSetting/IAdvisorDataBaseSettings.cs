namespace AdvisoryApp.DataBaseSetting
{
    public interface IAdvisorDataBaseSettings
    {
        string AdvisorCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
