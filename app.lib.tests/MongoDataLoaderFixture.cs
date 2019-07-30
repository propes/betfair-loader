using MongoDB.Bson;
using MongoDB.Driver;

namespace app.lib.tests
{
    public class MongoDataLoaderFixture
    {
        private const string TestDbName = "loader-test-db";
        private const string CollectionName = "points";
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        
        public FakeLogger Logger { get; private set; }

        public MongoDataLoaderFixture()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(TestDbName);
            Logger = new FakeLogger();
        }

        public MongoDataLoader CreateSut()
        {
            return new MongoDataLoader(_database, Logger);
        }

        public long CountRecords()
        {
            var collection = _database.GetCollection<BsonDocument>(CollectionName);

            return collection.CountDocuments(new BsonDocument());
        }

        public void Dispose()
        {
            _client.DropDatabase(TestDbName);
        }
    }
}