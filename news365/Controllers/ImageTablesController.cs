using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using news365.Models;

namespace news365.Controllers
{
    public class ImageTablesController : Controller
    {
        private news365Entities db = new news365Entities();

        // GET: ImageTables


        public ActionResult Edit(int id = 2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageTable imageTable = db.ImageTables.Find(id);
            if (imageTable == null)
            {
                return HttpNotFound();
            }
            return View(imageTable);
        }

        [HttpPost]
        //public ActionResult Edit([Bind(Include = "Img_id,Image,Text")] HttpPostedFileBase ImageFile)
        //{
            
        //    ImageTable setting = new ImageTable();

        //    try
        //    {

        //        string path = uploadimgfile(ImageFile);
        //        if (path.Equals("-1"))
        //        {
        //            ViewBag.error = "Image could not be uploaded....";
        //        }
        //        else
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                string fileName = Path.GetFileNameWithoutExtension(setting.ImageFile.FileName);
        //                string extension = Path.GetExtension(setting.ImageFile.FileName);
        //                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //                setting.Image = "~/Image/" + fileName;
        //                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
        //                setting.ImageFile.SaveAs(fileName);

        //                //db.Entry(setting).State = EntityState.Modified;
        //                //db.SaveChanges()

        //                //db.Entry(ImageFile).State = EntityState.Modified;
        //                //db.SaveChanges();
        //                //return RedirectToAction("Edit");
        //            }
        //            //return View();

        //            //    List<object> parameters = new List<object>();

        //            //    parameters.Add(path);
        //            //    parameters.Add(obj.Text);
        //            //parameters.Add(obj.Img_id);
        //            //    object[] objectarray = parameters.ToArray();

        //            //    int output = db.Database.ExecuteSqlCommand("update ImageTable set Image=@p0,Text=@p1 where Img_id=@p2", objectarray);
        //            //    if (output > 0)
        //            //    {
        //            //        ViewBag.Itemmsg = "Your profile is created seccussfully";
        //            //    }
        //        }


        //        return View();

        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}


        // Image uploading method
        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Images / "), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/imgfile/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }

            return path;
        }

    }
}
