using DbHandson.Data;
using DbHandson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbHandson.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _context;

        public ProductController(IRepository<Product> productRepository)
        {
            this._context = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.GetAllAsync(); // Fetch all products



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
                




                await _context.AddAsync(product);


                


                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.GetByIdAsync(id);

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

           await _context.UpdateAsync(product);
            //await _context.SaveChangesAsync();
             
            return RedirectToAction("Index");

            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.GetByIdAsync(id);
            if (product == null) return NotFound();

            await _context.DeleteAsync(product);
            //await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirect to product list
        }












    }
}
