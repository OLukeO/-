using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using 實驗室管理.Models;

namespace 實驗室管理.Controllers
{
    public class BooksController : Controller
    {
        private Laboratoryborrow1Entities db = new Laboratoryborrow1Entities();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string n_book_name)
        {
            var books = from Book in db.Books select Book;
            if (!String.IsNullOrEmpty(n_book_name)) 
            {
                books = books.Where(b => b.book_name.Contains(n_book_name));
            }
                 return View(await books.ToListAsync());
        }
        public ActionResult test()
        {
            var bookbuyer = db.Books.Join(db.Users, a => a.user_ID, c => c.user_ID, (a, c) 
              => new {a.book_name, c.name });
            return View(bookbuyer.ToList());
        }
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email");
            ViewBag.book_borrow_ID = new SelectList(db.book_borrow, "book_borrow_ID", "book_borrow_ID");
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email");
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email");
            return View();
        }

        // POST: Books/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_ID,book_name,ISBN,author,publicsh,book_borrow_ID,user_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.book_borrow_ID = new SelectList(db.book_borrow, "book_borrow_ID", "book_borrow_ID", book.book_borrow_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.book_borrow_ID = new SelectList(db.book_borrow, "book_borrow_ID", "book_borrow_ID", book.book_borrow_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            return View(book);
        }

        // POST: Books/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_ID,book_name,ISBN,author,publicsh,book_borrow_ID,user_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.book_borrow_ID = new SelectList(db.book_borrow, "book_borrow_ID", "book_borrow_ID", book.book_borrow_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            ViewBag.user_ID = new SelectList(db.Users, "user_ID", "email", book.user_ID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
