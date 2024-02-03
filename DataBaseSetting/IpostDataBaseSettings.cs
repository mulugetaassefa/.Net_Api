namespace AdvisoryApp.DataBaseSetting
{
    public interface IpostDataBaseSettings
    {
        string PostCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
