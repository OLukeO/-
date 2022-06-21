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
    public class book_reserveController : Controller
    {
        private Laboratoryborrow1Entities db = new Laboratoryborrow1Entities();

        // GET: book_reserve
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
    }
}
