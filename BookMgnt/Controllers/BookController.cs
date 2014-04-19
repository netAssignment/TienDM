using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMgnt.Models;

namespace BookMgnt.Controllers
{
    public class BookController : Controller
    {
        private BookContext db = new BookContext();

        // GET: /Book/
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: /Book/Details/5
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

        public ActionResult Category(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.Books.Where(a => a.CategoriesID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var cate = db.Categories.Find(id);
            ViewBag.TitleCategory = cate.Name;
            return View(book);
        }


        // GET: /Book/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase imagePath)
        {
            if (ModelState.IsValid)
            {
                if(imagePath != null && imagePath.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(imagePath.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/imageBook"), pic);
                    if (System.IO.File.Exists(path))
                    {
                        int count = 2;
                        while (System.IO.File.Exists(path))
                        {
                            pic = count.ToString() + pic;
                            path = System.IO.Path.Combine(Server.MapPath("~/Content/imageBook"), pic);
                        }
                    }
                    imagePath.SaveAs(path);
                    book.imagePath = pic;
                }
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "Name");
            return View(book);
        }

        // GET: /Book/Edit/5
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
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "Name");
            return View(book);
        }

        // POST: /Book/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Author,Introduce,imagePath,pubYear")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "Name");
            return View(book);
        }

        // GET: /Book/Delete/5
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

        // POST: /Book/Delete/5
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
