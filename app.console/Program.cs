using System;
using System.IO;
using System.Linq;
using app.lib;
using MongoDB.Driver;

namespace app.console
{
    class Program
    {
        private static readonly string DataDirectory = "/home/james/code/betfair/out";

        static void Main(string[] args)
        {
            if (!Directory.Exists(DataDirectory))
            {
                throw new Exception("Data directory is invalid");
            }

            var database = new MongoClient().GetDatabase("betfair");
            var logger = new Logger();
            var loader = new MongoDataLoader(database, logger);

            foreach (var file in Directory.GetFiles(DataDirectory))
            {
                Console.WriteLine($"Reading file {file}");
                loader.LoadFile(file);
            }

            Console.WriteLine("Finished reading all files");
            Console.WriteLine($"There were {logger.Errors.Count()} errors");
        }
    }
}
