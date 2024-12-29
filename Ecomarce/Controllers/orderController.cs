using Ecomarce.Models;
using Ecomarce.Models.Entites;
using Ecomarce.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecomarce.Controllers
{
    public class orderController: Controller
    {
        private readonly AppDbContext db;
        public orderController(AppDbContext app)
        {
            db = app;
        }
        [HttpGet]
        public  IActionResult choice()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> create(OrderViewModel v1)
        {
            var prod =await db.Products.ToListAsync();
            var cus =await db.Customers.ToListAsync();
            v1.Products = prod;
            v1.customers = cus;
            return View(v1);
        }
        [HttpPost]
        public async Task<IActionResult> create(OrderViewModel v1,Product p2)
        {
           var p1 =  db.Products.FirstOrDefault(P => P.ProductID == v1.ProductID);
            if (p1 != null)
            {
                p1.Quntity -= v1.Quntity;
                if (p1.Quntity > 0)
                {
                    var order = new Order()
                    {
                        CustomerID = v1.CustomerId,
                        OrderDate = DateTime.Now,
                        TotalAmount = v1.Quntity * p1.Price,
                    };
                    {
                        await db.Orders.AddAsync(order);
                        db.SaveChanges();
                    }
                    var orderitem = new OrderItems()
                    {
                         OrderID = order.OrderID,
                         ProductID = v1.ProductID,
                         Quantity = v1.Quntity,
                         Unitprice = p1.Price,
                    };
                    await db.OrderItems.AddAsync(orderitem);
                    db.SaveChanges();
                    return RedirectToAction("choice");
                }
                else
                {
                    return Content($"the avlible quntity is{p1.Quntity}");
                }
            }
            else
            {
                return Content("null");
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> ViewOrders()        
        {
            var o = await  db.Orders.Include(c => c.Customer).Where(x => x.Customer.CustomerId == x.CustomerID).ToListAsync();
            return View(o);
        }
    }
}
