using Csv_ProjectUI.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Csv_ProjectUI.Controllers
{
    public class CsvController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetCsvList()
        {
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync("https://localhost:44356/api/Csv/GetCsvList/");
                var jsonString = await responseMessage.Content.ReadAsStringAsync(); //asenkron olarak karsıla
                var values = JsonConvert.DeserializeObject<List<Csv>>(jsonString); //listelerken
                return View(values);
            }

        }
        public IActionResult AddCsv()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCsv(Csv csv)
        {
          
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(csv), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44356/api/Csv/AddCsv/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetCsvList");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız");
            return View(csv);

        }
    }
}
