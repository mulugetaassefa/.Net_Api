namespace AdvisoryApp.DataBaseSetting
{
    public interface IAppointmentDataBaseSettings
    {
        string AppointmentCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
