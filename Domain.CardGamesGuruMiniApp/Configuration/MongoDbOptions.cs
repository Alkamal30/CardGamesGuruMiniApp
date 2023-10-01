namespace Domain.CardGamesGuruMiniApp.Configuration
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public int Timeout { get; set; } = 30000;
    }
}