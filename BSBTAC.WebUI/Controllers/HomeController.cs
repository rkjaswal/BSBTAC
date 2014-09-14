using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSBTAC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadedFile)
        {
            // Verify that the user selected a file
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                var path = @"C:\Temp";
                // extract only the fielname
                var fileName = Path.GetFileName(uploadedFile.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(path, fileName);
                uploadedFile.SaveAs(path);
            }
            return View();
        }

        public ActionResult UploadFile1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile1(HttpPostedFileBase uploadedFile)
        {
            // Verify that the user selected a file
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                var path = @"C:\Temp";
                // extract only the fielname
                var fileName = Path.GetFileName(uploadedFile.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(path, fileName);
                uploadedFile.SaveAs(path);
            }
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}