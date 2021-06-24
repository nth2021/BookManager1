using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerConnect con = new BookManagerConnect();
            var ListBook = con.Books.ToList();
            return View(ListBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerConnect con = new BookManagerConnect();
            Book book = con.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult create()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("create")]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind(Include = "ID, Title, Description, Author, Images, Price")] Book book)
        {
            BookManagerConnect con = new BookManagerConnect();
            List<Book> listBook = con.Books.ToList();
            if (ModelState.IsValid)
            {
                con.Books.AddOrUpdate(book);
                con.SaveChanges();

            }
            return RedirectToAction("ListBook", listBook);
        }

        public ActionResult Edit(int? id)
        {
            BookManagerConnect con = new BookManagerConnect();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, Description,Author, Images, Price")] Book book)
        {
            BookManagerConnect con = new BookManagerConnect();
            List<Book> listBook = con.Books.ToList();
            if (ModelState.IsValid)
            {
                con.Books.AddOrUpdate(book);
                con.SaveChanges();
                
            }
            return RedirectToAction("ListBook", listBook);
        }

        public ActionResult Delete(int? id)
        {
            BookManagerConnect context = new BookManagerConnect();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(BookManagerConnect.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            BookManagerConnect context = new BookManagerConnect();
            List<Book> listBook = context.Books.ToList();
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook", listBook);
        }


    }
}