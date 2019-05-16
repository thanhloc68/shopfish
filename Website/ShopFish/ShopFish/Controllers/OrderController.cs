using ShopFish.Models;
using ShopFish.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopFish.Controllers
{
    
    public class OrderController : Controller
    {
        ShopDatabaseContext db = new ShopDatabaseContext();
        
        // GET: Order
        public ActionResult Checkout()
        {
     
            var cart = ShoppingCart.Cart;
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Login", "Login");
            }
            
            var model = new Orders();
            Accounts currentUser = (Accounts)Session["Username"];
            model.CustomerId = currentUser.Usernames;
            //model.CustomerId = User.Identity.Name;
            model.OrderDate = DateTime.Now.Date;
            model.Amount = ShoppingCart.Cart.Total;
            return View(model);
            }
  



        public ActionResult Purchase(Orders model)
        {
           
            db.Orders.Add(model);

            var cart = ShoppingCart.Cart;
          
            foreach (var p in cart.Items)
            {
                var d = new Ordersdetails
                {
                    Orders = model,
                    
                    ProductId = p.ID,
                    Product = p.Name,
                    UnitPrice = p.Price,
                    Quantity =  p.Quanlity

                };
              
                if (p.Quanlity - d.Quantity <= 0)
                {
                    ViewBag.alert = "Hết hàng";
                }
                else
                {
                   
                }

                db.Ordersdetails.Add(d);
                Products prod = (from a in db.Products where a.ID == p.ID select a).Single();
                if(prod.Quanlity > 0 && prod.Quanlity <=prod.Quanlity)
                {
                    prod.Quanlity -= p.Quanlity;
                }
                else
                {
                    RedirectToAction("Cart","Cart");
                }
            }

            db.SaveChanges();

            //Thanh toán trực tuyến
            //var api = new WebApiClient<AccountInfo>();
            //var data = new AccountInfo
            //{
            //    Id = Request["BankAccount"],
            //    Balance = cart.Total
            //};
            //api.Put("api/Bank/nn", data);
            return RedirectToAction("Detail", new { id = model.ID });
        }

        public ActionResult Detail(int id)
        {
            var order = db.Orders.Find(id);
            return View(order);
        }

        public ActionResult List()
        {
            var orders = db.Orders
                .Where(o => o.CustomerId == User.Identity.Name);
            return View(orders);
        }
    }
}