using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_ProjectUI.Core.Database.Interface
{
   public interface IMongoDbSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
