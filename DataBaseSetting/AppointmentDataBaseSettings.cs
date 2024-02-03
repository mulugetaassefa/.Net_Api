namespace AdvisoryApp.DataBaseSetting
{
    public class AppointmentDataBaseSettings :IAppointmentDataBaseSettings
    {
        public string AppointmentCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
