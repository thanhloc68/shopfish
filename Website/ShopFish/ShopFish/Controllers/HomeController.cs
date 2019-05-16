using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ShopFish.Models;
using ShopFish.ViewModels;

namespace ShopFish.Controllers
{
    public class HomeController : Controller
    {
        ShopDatabaseContext db = new ShopDatabaseContext();
 
        public ActionResult Index()
        {
            var product = db.Products.Where(d => d.Hot=="Hot").ToList().Take(8);
            return View(product);
        }

        [ChildActionOnly]
        public ActionResult Carouse()
        {
            //var baselineDate = DateTime.Now.AddDays(-7);
            var products = db.Products.Where(x => x.ID == x.ID).OrderByDescending(x => x.ID).Take(8).ToList();
           
            return PartialView("_Carouse", products);
        }
       
    }
}