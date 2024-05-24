using Bilet_12.DAL;
using Bilet_12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_12.Areas.Manage.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        [Area("Manage")]



        public class PortofolioController : Controller
        {
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _environment;

            public PortofolioController(AppDbContext context, IWebHostEnvironment environment)
            {
                _context = context;

                _environment = environment;
            }

            public IActionResult Index()
            {
                return View(_context.portfolios.ToList());
            }
            public IActionResult Create()
            {

                return View();
            }
            [HttpPost]
            public IActionResult Create(Portfolio portfolio)
            {
                string path = _environment.WebRootPath + @"\Upload\Portofolio\";
                string filename = portfolio.ImgFile.FileName;
                using (FileStream fileStream = new FileStream(path + filename, FileMode.Create))
                {
                    portfolio.ImgFile.CopyTo(fileStream);
                }
                portfolio.ImgUrl = filename;
                _context.portfolios.Add(portfolio);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult Delete(Portfolio portfolio)
            {
                string path = _environment.WebRootPath + @"\Upload\Portofolio\";
                string filename = portfolio.ImgFile!.FileName;
                using (FileStream fileStream = new FileStream(path + filename, FileMode.Create))
                {
                    portfolio.ImgFile.CopyTo(fileStream);
                }
                return View(); 
            }
            public IActionResult Delete(int Id)
            {
                //get the staff with the Id
                var staff = _context.portfolios.FirstOrDefault(e => e.Id == Id);
                //remove the staff from the database
                _context.portfolios.Remove(staff);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            [HttpPost]
            public IActionResult Update(Portfolio portfolio)
            {
                //get the existing staff
                var old_staff = _context.portfolios.FirstOrDefault(e => e.Id == portfolio.Id);
                //update with new staff information
                _context.Entry(old_staff).CurrentValues.SetValues(portfolio);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
          
        }
        public IActionResult Index()
        {



            return View();
        }
    }
}
