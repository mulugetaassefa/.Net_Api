namespace AdvisoryApp.DataBaseSetting
{
    public interface IStudentDataBaseSettings
    {

        string StudentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
