using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using news365.Models;

namespace news365.Controllers
{
    public class NewsTablesController : Controller
    {
        private news365Entities db = new news365Entities();

        // GET: NewsTables
        public ActionResult Index()
        {
            var newsTables = db.NewsTables.Include(n => n.CategoryTable);
            return View(newsTables.ToList());
        }


        public ActionResult NewsList(int id = 0)
        {
            NewsTable news = new NewsTable();
            using (news365Entities db = new news365Entities())
            {
                news.NewsCategories = db.CategoryTables.ToList<CategoryTable>();
            }

            return View(news);
        }
        [HttpPost]
        public ActionResult NewsList([Bind(Include = "NewsID,CategoryID,Description")] NewsTable newsTable)
        {

            if (ModelState.IsValid)
            {
                db.NewsTables.Add(newsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryTables, "CategoryID", "CategoryName", newsTable.CategoryID);
            return View(newsTable);
        }





        // GET: NewsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTable newsTable = db.NewsTables.Find(id);
            if (newsTable == null)
            {
                return HttpNotFound();
            }
            return View(newsTable);
        }

       
        // GET: NewsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTable newsTable = db.NewsTables.Find(id);
            if (newsTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTables, "CategoryID", "CategoryName", newsTable.CategoryID);
            return View(newsTable);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsID,CategoryID,Description")] NewsTable newsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CategoryTables, "CategoryID", "CategoryName", newsTable.CategoryID);
            return View(newsTable);
        }

        // GET: NewsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTable newsTable = db.NewsTables.Find(id);
            if (newsTable == null)
            {
                return HttpNotFound();
            }
            return View(newsTable);
        }

        // POST: NewsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsTable newsTable = db.NewsTables.Find(id);
            db.NewsTables.Remove(newsTable);
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
