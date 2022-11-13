namespace CityInfo.API.ConfigModels
{
    public class NodeDatabaseSettings :
    INodeDatabaseSettings
    {
        public string CSGSICollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class INodeDatabaseSettings
    {
        public string CSGSICollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
