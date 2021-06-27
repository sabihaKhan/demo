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
    public class Smtp_tableController : Controller
    {
        private news365Entities db = new news365Entities();

     
       
       
        // GET: Smtp_table/Edit/5
        public ActionResult Edit(int id = 3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smtp_table smtp_table = db.Smtp_table.Find(id);
            if (smtp_table == null)
            {
                return HttpNotFound();
            }
            return View(smtp_table);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "smtp_id,Smtp_protocol,Smtp_host,Smtp_port,Smtp_username,Smtp_password,Smtp_mail_type,Smtp_charset")] Smtp_table smtp_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smtp_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(smtp_table);
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
