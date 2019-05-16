using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using ShopFish.Models;
namespace ShopFish.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        ShopDatabaseContext db = new ShopDatabaseContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.abc = (from p in db.Orders orderby Guid.NewGuid() select p).ToList();
            ViewBag.feedbacks = (from p in db.Feedbacks orderby Guid.NewGuid() select p).ToList();
            ViewBag.accounts = (from p in db.Accounts orderby Guid.NewGuid()  select p).ToList();
            ViewBag.suppliers = (from p in db.Suppliers orderby Guid.NewGuid() select p).ToList();
            var r = (from p in db.Orders where p.ID == p.ID select p).ToList().Count();

            return View(r);
        }

        [WebMethod]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ActionResult Data()
        {

            
            var abc = from obj in db.Orders group obj by new { obj.Amount, obj.OrderDate } into g select new { Tongtien = g.Sum(x=>x.Amount), Ngaymua = g.Select(x=>x.OrderDate.Value.Year.ToString()) };

            return Json(abc, JsonRequestBehavior.AllowGet);
            //    return View();
            //}
        }
    }
}