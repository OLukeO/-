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
    public class book_borrowController : Controller
    {
        private Laboratoryborrow1Entities db = new Laboratoryborrow1Entities();

        // GET: book_borrow
        public ActionResult Index()
        {
            return View(db.book_borrow.ToList());
        }

        // GET: book_borrow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book_borrow book_borrow = db.book_borrow.Find(id);
            if (book_borrow == null)
            {
                return HttpNotFound();
            }
            return View(book_borrow);
        }

        // GET: book_borrow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: book_borrow/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_borrow_ID,book_borrow_sart_time,book_borrow_estionate_end_time,book_borrow_actual_ent_time,state")] book_borrow book_borrow)
        {
            if (ModelState.IsValid)
            {
                db.book_borrow.Add(book_borrow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book_borrow);
        }

        // GET: book_borrow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book_borrow book_borrow = db.book_borrow.Find(id);
            if (book_borrow == null)
            {
                return HttpNotFound();
            }
            return View(book_borrow);
        }

        // POST: book_borrow/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_borrow_ID,book_borrow_sart_time,book_borrow_estionate_end_time,book_borrow_actual_ent_time,state")] book_borrow book_borrow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_borrow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book_borrow);
        }

        // GET: book_borrow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book_borrow book_borrow = db.book_borrow.Find(id);
            if (book_borrow == null)
            {
                return HttpNotFound();
            }
            return View(book_borrow);
        }

        // POST: book_borrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book_borrow book_borrow = db.book_borrow.Find(id);
            db.book_borrow.Remove(book_borrow);
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
