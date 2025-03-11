using DbHandson.Data;
using DbHandson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbHandson.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.productinfo.ToListAsync(); // Fetch all products
            return View(products);
        }


        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)


        {

            if (ModelState.IsValid)
            {
                




                await _context.productinfo.AddAsync(product);


                await _context.SaveChangesAsync();


                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.productinfo.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(id);
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.productinfo.FindAsync(id);
            if (product == null) return NotFound();

            _context.productinfo.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirect to product list
        }












    }
}
