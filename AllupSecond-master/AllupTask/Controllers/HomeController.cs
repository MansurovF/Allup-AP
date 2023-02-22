using AllupTask.DataAccessLayer;
using AllupTask.Models;
using AllupTask.Services;
using AllupTask.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace AllupTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
         

        public HomeController(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM {

                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                Categories = await _context.Categories.Where(c => c.IsDeleted == false && c.IsMain).ToListAsync(),
                BestSeller = await _context.Products.Where(c => c.IsDeleted == false && c.IsBestseller).ToListAsync(),
                Featured = await _context.Products.Where(c => c.IsDeleted == false && c.IsFeatured).ToListAsync(),
                NewArrival = await _context.Products.Where(c => c.IsDeleted == false && c.IsNewArrival).ToListAsync(),
            };


            return View(homeVM);
        }


        //public IActionResult SetSession() 
        //{
        //    HttpContext.Session.SetString("P229Session", "P229 first session");

        //    return Content("Session added");
        //}

        //public IActionResult GetSession()
        //{
        //    string session = HttpContext.Session.GetString("P229Session");

        //    return Content(session);
        //}

        //public IActionResult SetCookie()
        //{
        //    HttpContext.Response.Cookies.Append("P229Cookie", "P229 first session");

        //    return Content("Cookie added");
        //}

        //public IActionResult GetCookie()
        //{
        //    string cookie = HttpContext.Request.Cookies["P229Cookie"];

        //    return Content(cookie);
        //}

    }

}
