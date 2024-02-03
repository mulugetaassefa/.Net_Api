
using AdvisoryApp.DataBaseSetting;

namespace AdvisoryApp.DataBaseSetting
{
    public class PostDataBaseSettings : IpostDataBaseSettings
    {
        public string PostCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
