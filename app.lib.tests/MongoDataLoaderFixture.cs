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
        private readonly IMongoCollection<BsonDocument> _collection;
        
        public FakeLogger Logger { get; private set; }

        public MongoDataLoaderFixture()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(TestDbName);
            _collection = _database.GetCollection<BsonDocument>(CollectionName);
            Logger = new FakeLogger();
        }

        public MongoDataLoader CreateSut()
        {
            return new MongoDataLoader(_collection, Logger);
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