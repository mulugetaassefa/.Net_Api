﻿namespace AdvisoryApp.DataBaseSetting
{
    public interface IChatDatabaseSettings
    {
        string ChatCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
