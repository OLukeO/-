using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 實驗室管理.Models;

namespace 實驗室管理.Controllers
{
    public class UsersController : Controller
    {
        private Laboratoryborrow1Entities db = new Laboratoryborrow1Entities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Auth).Include(u => u.department).Include(u => u.Token);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.auth_ID = new SelectList(db.Auths, "auth_ID", "auth_name");
            ViewBag.department_ID = new SelectList(db.departments, "department_ID", "name");
            ViewBag.user_ID = new SelectList(db.Tokens, "user_ID", "token1");
            return View();
        }

        // POST: Users/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_ID,email,password,name,auth_ID,department_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auth_ID = new SelectList(db.Auths, "auth_ID", "auth_name", user.auth_ID);
            ViewBag.department_ID = new SelectList(db.departments, "department_ID", "name", user.department_ID);
            ViewBag.user_ID = new SelectList(db.Tokens, "user_ID", "token1", user.user_ID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.auth_ID = new SelectList(db.Auths, "auth_ID", "auth_name", user.auth_ID);
            ViewBag.department_ID = new SelectList(db.departments, "department_ID", "name", user.department_ID);
            ViewBag.user_ID = new SelectList(db.Tokens, "user_ID", "token1", user.user_ID);
            return View(user);
        }

        // POST: Users/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_ID,email,password,name,auth_ID,department_ID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auth_ID = new SelectList(db.Auths, "auth_ID", "auth_name", user.auth_ID);
            ViewBag.department_ID = new SelectList(db.departments, "department_ID", "name", user.department_ID);
            ViewBag.user_ID = new SelectList(db.Tokens, "user_ID", "token1", user.user_ID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
