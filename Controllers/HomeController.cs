using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;
        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            
            string value = System.DateTime.Now.ToString();
           
                
               // value = System.DateTime.Now.ToString();
                _cache.SetString("CacheTime", value);
            
            ViewData["CacheTime"] = value;
            ViewData["CurrentTime"] = System.DateTime.Now.ToString();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
