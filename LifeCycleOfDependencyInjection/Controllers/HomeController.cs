using LifeCycleOfDependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCycleOfDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingleton singleton;
        private readonly ITransient transient;
        private readonly IScoped scoped;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ISingleton singleton , IScoped Scoped ,ITransient transient)
        {//global değişkene tasımak ıcın: yanı yukarda sıngleton yapıp asagıda hayata gecırmemn lazım
            this.singleton = singleton;
            this.transient = transient;
            this.scoped = Scoped;
            //this.Scoped =Scoped;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // burda ürettikleri guidleri view baga gönderıyoz

            ViewBag.Singleton = singleton.Guid.ToString();
            ViewBag.Transient = transient.Guid.ToString();

            ViewBag.Scoped = scoped.Guid.ToString();




            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
