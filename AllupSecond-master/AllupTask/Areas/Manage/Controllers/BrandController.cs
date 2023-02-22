using AllupTask.DataAccessLayer;
using AllupTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllupTask.Areas.Manage.Controllers
{
    [Area("manage")]

    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task <IActionResult> Index()
        {
            IEnumerable<Brand> brands = await _context.Brands.Include(b=>b.Products).Where(b => b.IsDeleted == false).ToListAsync();

            return View(brands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            if (await _context.Brands.AnyAsync(b=>b.IsDeleted == false && b.Name.ToLower()==brand.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", $" This brand {brand.Name} already exists");
                return View(brand);
            }

            brand.Name = brand.Name.Trim();
            brand.CreatedBy = "System";
            brand.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       
    }
}
