using news365.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using news365.Models;

namespace news365.Controllers
{
    public class HomeController : Controller
    {
        private news365Entities db = new news365Entities();
        private object newsTable;

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
                return RedirectToAction("NewsList");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryTables, "CategoryID", "CategoryName", newsTable.CategoryID);
            return View(newsTable);
        }

        //public ActionResult Index()
        //{
        //    var newsTables = db.NewsTables.Include(n => n.CategoryTable);
        //    return View(newsTables.ToList());
        //}



    }
}

