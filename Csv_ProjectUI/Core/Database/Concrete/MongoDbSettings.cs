using Csv_ProjectUI.Core.Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_ProjectUI.Core.Database.Concrete
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
