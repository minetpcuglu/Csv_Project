using Csv_ProjectUI.Core.Database.Interface;
using Csv_ProjectUI.Entities;
using Csv_ProjectUI.Services.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_ProjectUI.Services.Concrete
{
    public class CsvService:ICsvService
    {
        private readonly IMongoCollection<Csv> _collection;
        private readonly IMongoCollection<Csv> _csv;
        List<BsonDocument> batch = new List<BsonDocument>();

        public CsvService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Csv>(settings.CollectionName);
            _csv = database.GetCollection<Csv>(settings.CollectionName);
        }
        public async Task<Csv> Create(Csv model)
        {
            await _collection.InsertOneAsync(model);
            return model;
        }

        public async Task<IEnumerable<Csv>> GetCsvList()
        {

            var reader = new StreamReader(File.OpenRead(@"C:\Users\minet\Desktop\asp.net core\Csv_Project\Csv_ProjectUI\ornek_csv\xrtest_1500120_1_1641547130799.csv")); // where <full path to csv> is the file path, of course
           
            reader.ReadLine(); // to skip header

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Csv row = new Csv();
                row.MainLevel_id = Convert.ToInt32(values[0]);
                row.XRmean = Convert.ToInt32(values[1]);
                row.XRmin = Convert.ToInt32(values[2]);
                row.XRmax = Convert.ToInt32(values[3]);
                row.SDNN = Convert.ToSingle(values[4]);
                row.Rmssd = Convert.ToSingle(values[5]);
                row.NN50 = Convert.ToSingle(values[6]);
                row.pNN50 = Convert.ToSingle(values[7]);
                row.ValueIndex = Convert.ToSingle(values[8]);
                row.created_at = Convert.ToInt64(values[9]);
            }
           
             var personels = await _collection.FindAsync(x => true).Result.ToListAsync();
            return personels;

        }

        public async Task<IEnumerable<Csv>> TotelAddCsvList()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\minet\Desktop\asp.net core\Csv_Project\Csv_ProjectUI\ornek_csv\xrtest_1500120_1_1641547130799.csv")); // where <full path to csv> is the file path, of course

            reader.ReadLine(); // to skip header

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Csv row = new Csv();
                row.MainLevel_id = Convert.ToInt32(values[0]);
                row.XRmean = Convert.ToInt32(values[1]);
                row.XRmin = Convert.ToInt32(values[2]);
                row.XRmax = Convert.ToInt32(values[3]);
                row.SDNN = Convert.ToSingle(values[4]);
                row.Rmssd = Convert.ToSingle(values[5]);
                row.NN50 = Convert.ToSingle(values[6]);
                row.pNN50 = Convert.ToSingle(values[7]);
                row.ValueIndex = Convert.ToSingle(values[8]);
                row.created_at = Convert.ToInt64(values[9]);

                _csv.InsertOne(row);
            }

            var AddList = await _collection.FindAsync(x => true).Result.ToListAsync();
            return AddList;
        }
    }
}

