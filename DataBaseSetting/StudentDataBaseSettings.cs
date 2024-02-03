using AdvisoryApp.DataBaseSetting;

namespace AdvisoryApp.DataBaseSetting
{
    public class StudentDataBaseSettings :IStudentDataBaseSettings
    {
        public string StudentCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

    }
}
