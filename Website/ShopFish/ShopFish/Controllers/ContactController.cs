using ShopFish.Models;
using ShopFish.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ShopFish.Controllers
{
    public class ContactController : Controller
    {
        ShopDatabaseContext db = new ShopDatabaseContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(ContactViewModel contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {

                
                        var user = new Feedback();
                        user.Name = contacts.Name;
                        user.Phone = contacts.Phone;
                        user.address = contacts.address;
                        user.Content = contacts.Content;
                        user.Createdate = DateTime.Now;
                        user.email = contacts.email;
                        user.status = false;

                        var result = db.Feedbacks.Add(user);
                        db.SaveChanges();

                        //var result = db.Entry(register).State = EntityState.Added;
                        //db.SaveChanges();
                        if (result != null)
                        {
                            ViewBag.Success = "Đã gửi thông tin! chúng tôi sẽ phản hồi qua email";
                            ModelState.Clear();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng kí không thành công");
                        }
            
                }
            }


            catch (Exception ex)
            {

            }
            //return RedirectToAction("Login", "Login");
            return View(contacts);
      
        }
        public ActionResult News(int? id)
        {
            try
            {
                ViewBag.home = (from p in db.Blogs orderby Guid.NewGuid() select p).ToList();
                ViewBag.cacanh = (from c in db.Blogs where c.TypeBlogs.ID == 1 orderby Guid.NewGuid() select c).ToList();
                ViewBag.hoca = (from h in db.Blogs where h.TypeBlogs.ID==2 orderby Guid.NewGuid() select h).ToList();
                ViewBag.thucan = (from t in db.Blogs where t.TypeBlogs.ID == 3 orderby Guid.NewGuid() select t).ToList();
            }
            catch { }
            return View();
        }
           public ActionResult DetailBlogs(int? id)
        {
            try
            {
                var detailblog = (from a in db.Blogs
                                  where a.ID == id
                                  select new BlogModelVIew()
                                  {
                                      ID = a.ID,
                                      Title = a.Title,
                                      HeadBlog = a.HeadBlog,
                                      BodyBlog = a.BodyBlog,
                                      FootBlog = a.FootBlog,
                                      image1 = a.image1,
                                      CreateDay = a.CreateDay
                                  }).FirstOrDefault();


                return View(detailblog);
            }
            catch
            {
                
            }
            return View();
        }

          
           
        }
    }
