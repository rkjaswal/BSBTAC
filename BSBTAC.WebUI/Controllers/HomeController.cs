using BSBTAC.Domain;
using BSBTAC.Domain.Models;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Ninject;

namespace BSBTAC.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        [Inject]
        public HomeController([Named("BSBTAC")] IUnitOfWork uow)
        {
            _uow = uow;
        }
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
            if (uploadedFile == null)
            {
                ViewBag.Message = "Select a file to upload";
            }
            else
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

        public ActionResult UploadFile1(int page = 1)
        {
            var uploaddetail = _uow.Repository<UploadDetail>().Query().Get()
                .OrderBy(u => u.UploadDatetime)
                .ToPagedList(page, 1);
            return View(uploaddetail);
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
            return RedirectToAction("UploadFile1");
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}