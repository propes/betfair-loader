using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace app.lib
{
    public class MongoDataLoader
    {
        private const string CollectionName = "points";

        private readonly IMongoCollection<BsonDocument> _collection;
        private readonly ILogger _logger;

        public MongoDataLoader(
            IMongoDatabase database,
            ILogger logger)
        {
            _collection = database.GetCollection<BsonDocument>(CollectionName);
            _logger = logger;
        }

        public void LoadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File does not exist", nameof(filePath));
            }

            var lines = File.ReadAllLines(filePath);
            for (var i = 0; i < lines.Length; i++)
            {
                BsonDocument document = null;
                try
                {
                    document = BsonDocument.Parse(lines[i]);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{filePath}: line {i}: Error parsing line: {ex.Message}");
                    continue;
                }

                try
                {
                    _collection.InsertOne(document);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{filePath}: line {i}: Error inserting document: {ex.Message}");
                }
            }
        }
    }
}