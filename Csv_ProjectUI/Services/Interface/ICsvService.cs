using Csv_ProjectUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_ProjectUI.Services.Interface
{
    public interface ICsvService
    {
        Task<IEnumerable<Csv>> GetCsv();
        Task<IEnumerable<Csv>> TotelAddCsv();
        Task<Csv> Create(Csv model);
    }
}
