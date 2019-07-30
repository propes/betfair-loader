using System;
using System.IO;
using System.Linq;
using app.lib;
using app.lib.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace app.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = args[0];

            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                Console.WriteLine("Please provide a directory for data files");
            }

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory specified does not exist");
                return;
            }

            var database = new MongoClient().GetDatabase("betfair");
            var collection = database.GetCollection<BsonDocument>("points");
            var logger = new Logger();

            var loader = new MongoDataLoader(collection, logger);

            var files = Directory.GetFiles(directoryPath);
            for (var i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"Reading file {i+1}/{files.Length}: {files[i]}");
                loader.LoadFile(files[i], false);
            }

            Console.WriteLine($"Finished reading {files.Length:n0} files");
            Console.WriteLine($"{logger.RecordCount:n0} records processed");
            Console.WriteLine($"{logger.SuccessCount:n0} successful");
            Console.WriteLine($"{logger.Errors.Count():n0} errors");
            Console.WriteLine($"{logger.Duplicates.Count():n0} duplicates");
        }
    }
}
