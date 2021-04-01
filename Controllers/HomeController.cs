using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BridgeMonitor.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace BridgeMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var fermetures = GetFermetureFromApi();
            var fermeture = fermetures[0];
            fermeture.Duration = fermeture.ReopeningDate.Subtract(fermeture.ClosingDate);
            fermeture.ClosingDateString = fermeture.ClosingDate.ToString("dddd, dd MMMM yyyy HH:mm");
            fermeture.ReopeningDateString = fermeture.ReopeningDate.ToString("dddd dd MMMM yyyy HH:mm");
            

            return View(fermeture);
        }

        public IActionResult Toutes(){
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<Fermeture> GetFermetureFromApi(){
            using(var client = new HttpClient()){
                var response = client.GetAsync("https://api.alexandredubois.com/pont-chaban/api.php");
                var stringResult = response.Result.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Fermeture>>(stringResult.Result);
                return result;
            }
        }
    }
}
