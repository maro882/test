using Ecomarce.Models;
using Ecomarce.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Ecomarce.Controllers
{
    public class productController: Controller
    {
        AppDbContext db;
        public productController(AppDbContext db1)
        {
            db=db1;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var prod = await db.Products.ToListAsync();
            return View(prod);
        }
        [HttpGet]
        public async Task<IActionResult> add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add(Product product)
        {
            Product p1 = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quntity = product.Quntity,
            };
           await db.Products.AddAsync(p1);
           await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
        {
            var prod =await db.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        [HttpPost]
        public async Task<IActionResult> update(int id,Product product)
        {
            var prod = await db.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Description = product.Description;
            db.Products.Update(prod);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> delete(int id)
        {
            var prod = await db.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        [HttpPost]
        public async Task<IActionResult> delete(int id, Product product)
        {
            product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
