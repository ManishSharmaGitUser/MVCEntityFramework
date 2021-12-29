using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FileUploadClass model)
        {
            if (model.File == null)
            {
                ModelState.AddModelError(string.Empty, "No File for Upload");
                return View();
            }

            string path = Server.MapPath("~/UploadedFile");
            string Filename = Path.GetFileName(model.File.FileName);

            string fullpath = Path.Combine(path, Filename);
            model.File.SaveAs(fullpath);
            return View();
        }

        public FileResult Download()
        {
            //put this ~/UploadedFile in config file
            string path = Server.MapPath("~/UploadedFile");
            string Filename = Path.GetFileName("9.jpg"); // get filename from passing parameter

            string fullpath = Path.Combine(path, Filename);
            return File(fullpath, "image/jpg");
        }
    }
}