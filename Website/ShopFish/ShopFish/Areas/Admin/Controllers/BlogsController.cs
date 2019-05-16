using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopFish.Models;

namespace ShopFish.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogsController : Controller
    {
        private ShopDatabaseContext db = new ShopDatabaseContext();

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Admin/Blogs/Details/5
       

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,HeadBlog,BodyBlog,FootBlog,CreateDay,Type")] Blog blog, HttpPostedFileBase Uploadimg)
        {
            if (ModelState.IsValid)
            {
                blog.CreateDay = DateTime.Now;
                if (Uploadimg != null && Uploadimg.ContentLength > 0)
                {
                    if (Uploadimg.ContentType == "image/jpg" || Uploadimg.ContentType == "image/png" || Uploadimg.ContentType == "image/jpeg" || Uploadimg.ContentType == "image/gif")
                    {
                        Uploadimg.SaveAs(Server.MapPath("~/Content/img/") + Uploadimg.FileName);
                        blog.image1= Uploadimg.FileName;
                    }
                    else
                        return View();
                }
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,HeadBlog,BodyBlog,image1,FootBlog,CreateDay,Type")] Blog blog, HttpPostedFileBase Uploadimg)
        {
            if (ModelState.IsValid)
            {
                if (Uploadimg != null && Uploadimg.ContentLength > 0)
                {
                    if (Uploadimg.ContentType == "image/jpg" || Uploadimg.ContentType == "image/png" || Uploadimg.ContentType == "image/jpeg" || Uploadimg.ContentType == "image/gif")
                    {
                        Uploadimg.SaveAs(Server.MapPath("~/Content/img/") + Uploadimg.FileName);
                        blog.image1 = Uploadimg.FileName;
                    }
                    else
                        return View();
                }
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
