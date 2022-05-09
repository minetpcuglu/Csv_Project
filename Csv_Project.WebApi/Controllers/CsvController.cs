using Csv_ProjectUI.Entities;
using Csv_ProjectUI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Csv_Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly ICsvService _csvService;
        public CsvController(ICsvService csvService) => _csvService = csvService;


        [HttpGet]
        [Route("GetCsvList")]
        [ProducesResponseType(typeof(List<Csv>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetListAll()
        {
            return Ok(await _csvService.GetCsvList());
        }

        [HttpPost]
        [Route("AddCsv")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Csv csv)
        {
            return Ok(await _csvService.Create(csv));
        }

    }
}
