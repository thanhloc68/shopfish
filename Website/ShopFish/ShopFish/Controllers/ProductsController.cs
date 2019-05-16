using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using ShopFish.Models;
using ShopFish.ViewModels;
using System.Net;

namespace ShopFish.Controllers
{
    public class ProductsController : Controller
    {
        ShopDatabaseContext db = new ShopDatabaseContext();
        // GET: Products
        public ActionResult CVLT(int LoaiSp_ID = 2)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new  ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CVLT"
            });
        }
        public ActionResult CCV(int LoaiSp_ID=1)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CCV"
            });
        }
        public ActionResult CD(int LoaiSp_ID = 3)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CD"
            });
        }
        public ActionResult CLH(int LoaiSp_ID = 4)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CLH"
            });
        }
        public ActionResult CR(int LoaiSp_ID = 5)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CR"
            });
        }
        public ActionResult CK(int LoaiSp_ID = 6)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "CK"
            });
        }
        public ActionResult TACC(int LoaiSp_ID = 7)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "TACC"
            });
        }
        public ActionResult BCDB(int LoaiSp_ID = 8)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "BCDB"
            });
        }
        public ActionResult BCTT(int LoaiSp_ID = 9)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "BCTT"
            });
        }
        public ActionResult BCPT(int LoaiSp_ID = 10)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "BCPT"
            });
        }
        public ActionResult BCCTG(int LoaiSp_ID = 11)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "BCCTG"
            });
        }
        public ActionResult BCMN(int LoaiSp_ID = 12)
        {
            var products = db.Products.Where(p => p.Categories.ID == LoaiSp_ID).Select(x => new ProductsViewModels()
            {
                ID = x.ID,
                Image = x.Image,
                Name = x.Name,
                Price = x.Price,

            }).ToList();

            return View(new MenuListSp()
            {
                Products = products,
                Link = "BCMN"
            });
        }
        public ActionResult Detail(int? id)
        {

            //var detailproduct = db.Products.Where(p => p.ID == id ).FirstOrDefault();
            ////var categories = db.Categories.Where(p => p.ID == id).FirstOrDefault();
            ////var suppliers = db.Suppliers.Where(p => p.ID == id).FirstOrDefault();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ProductDetail model = new ProductDetail()
            //{
            // ID = detailproduct.ID,
            // Name = detailproduct.Name,
            // //NameSup = suppliers.Name,
            // //NameCate = categories.Name,
            // Quanlity = detailproduct.Quanlity,
            // Price = detailproduct.Price,
            // Image = detailproduct.Image,
            // Descriptions = detailproduct.Descriptions,
            // LivingEnvironment = detailproduct.LivingEnvironment,
            // GeneralFeatures = detailproduct.GeneralFeatures,
            // Createdates = detailproduct.Createdates
            //};
            //    return View(model);
            //try
            //{
            //    ViewBag.abc = (from p in db.Products orderby Guid.NewGuid() select p).Take(4).ToList();

            //    var detailproduct = (from a in db.Products
            //                     join b in db.Categories

            //                     on a.Categories.ID equals b.ID
            //                     join c in db.Suppliers
            //                     on a.Suppliers.ID equals c.ID
            //                     where a.ID == id
            //                     select new ProductDetail()
            //                     {
            //                         ID = a.ID,
            //                         Name = a.Name,
            //                         NameSup = c.Name,
            //                         NameCate = b.Name,
            //                         Quanlity = a.Quanlity,
            //                         Price = a.Price,
            //                         Image = a.Image,
            //                         Descriptions = a.Descriptions,
            //                         LivingEnvironment = a.LivingEnvironment,
            //                         GeneralFeatures = a.GeneralFeatures,
            //                         Createdates = a.Createdates,
            //                         viewcount = a.viewcount
            //                     }).FirstOrDefault();


            //    detailproduct.viewcount++;
            //    db.SaveChanges();
            //    // Lấy cookie cũ tên views
            //    var views = Request.Cookies["views"];
            //    // Nếu chưa có cookie cũ -> tạo mới
            //    if (views == null)
            //    {
            //        views = new HttpCookie("views");
            //    }
            //    // Bổ sung mặt hàng đã xem vào cookie
            //    views.Values[id.ToString()] = id.ToString();
            //    // Đặt thời hạn tồn tại của cookie
            //    views.Expires = DateTime.Now.AddMonths(1);
            //    // Gửi cookie về client để lưu lại
            //    Response.Cookies.Add(views);
            //    // Lấy List<int> chứa mã hàng đã xem từ cookie
            //    var keys = views.Values
            //        .AllKeys.Select(k => int.Parse(k)).ToList();
            //    return View(detailproduct);
            //}
            //catch { }
            ViewBag.abc = (from p in db.Products orderby Guid.NewGuid() select p).Take(4).ToList();
            var model = db.Products.Find(id);

            // Tăng số lần xem
            model.viewcount++;
            db.SaveChanges();

            // Lấy cookie cũ tên views
            var views = Request.Cookies["views"];
            // Nếu chưa có cookie cũ -> tạo mới
            if (views == null)
            {
                views = new HttpCookie("views");
            }
            // Bổ sung mặt hàng đã xem vào cookie
            views.Values[id.ToString()] = id.ToString();
            // Đặt thời hạn tồn tại của cookie
            views.Expires = DateTime.Now.AddMonths(1);
            // Gửi cookie về client để lưu lại
            Response.Cookies.Add(views);

            // Lấy List<int> chứa mã hàng đã xem từ cookie
            var keys = views.Values
                .AllKeys.Select(k => int.Parse(k)).ToList();
            // Truy vấn háng đãn xem
            ViewBag.Views = db.Products
                .Where(p => keys.Contains(p.ID));
            return View(model);
            

        }
        public ActionResult Search(String SupplierId = "", int CategoryId = 0, String Keywords = "")
        {
            if (SupplierId != "")
            {
                var model = db.Products
                    .Where(p => p.Suppliers.Name == SupplierId);
                return View(model);
            }
            else if (CategoryId != 0)
            {
                var model = db.Products
                    .Where(p => p.Categories.ID == CategoryId);
                return View(model);
            }
         
            else if (Keywords != "")
            {
                var model = db.Products
                    .Where(p => p.Name.Contains(Keywords) || p.Product_Code.Contains(Keywords));
                return View(model);
            }
            
            return View(db.Products);
        }
       
    }
}