using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ShopFish.Models;

namespace ShopFish.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountsController : Controller
    {
        private ShopDatabaseContext db = new ShopDatabaseContext();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Roles);
            return View(accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
     

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.IDRole = new SelectList(db.Roles, "IDRole", "Name");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Usernames,Passwords,NameUser,Gender,Tel,Addresss,email,ResetPasswordCode,createsdate,IDRole")] Accounts accounts)
        {
            ViewBag.IDRole = new SelectList(db.Roles, "IDRole", "Name", accounts.IDRole);
            if (ModelState.IsValid)
            {
                var IsExitUser = checkuser(accounts.Usernames);
                var IsExitEmail = checkuser(accounts.email);
                if (IsExitUser)
                {
                    ViewBag.Note = "Tài khoản đã tồn tại";
                    return View(accounts);
                }
                else if (IsExitEmail)
                {
                    ViewBag.Note = "email đã tồn tại";
                    return View(accounts);
                }
                else { 
                   
                accounts.createsdate = DateTime.Now;
                accounts.Passwords = Crypto.HashPassword(accounts.Passwords);
                db.Accounts.Add(accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }

          
            return View(accounts);
        }
        public bool checkuser(string Username)
        {
            return db.Accounts.Count(x => x.Usernames == Username) > 0;
        }
        public bool checkemail(string Emailuser)
        {
            return db.Accounts.Count(x => x.email == Emailuser) > 0;
        }
        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDRole = new SelectList(db.Roles, "IDRole", "Name", accounts.IDRole);
            return View(accounts);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Usernames,Passwords,NameUser,Gender,Tel,Addresss,email,createsdate,IDRole")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
               
                accounts.createsdate = DateTime.Now;
                accounts.Passwords = Crypto.HashPassword(accounts.Passwords);
                db.Entry(accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDRole = new SelectList(db.Roles, "IDRole", "Name", accounts.IDRole);
            return View(accounts);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts accounts = db.Accounts.Find(id);
            db.Accounts.Remove(accounts);
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
