using Microsoft.AspNetCore.Mvc;

namespace Bilet_12.Areas.Manage.Controllers
              
{
    public class PortfolioControllers : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }
    }
}


