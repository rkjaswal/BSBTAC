using System.Data.SqlClient;
using System.Security.Policy;
using BSBTAC.Domain.Models;
using BSBTAC.WebUI.ViewModels;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace BSBTAC.WebUI.Controllers
{
    public class CADMController : BaseController
    {
        private readonly IUnitOfWork _cadmuow;
        [Inject]
        public CADMController([Named("BSBTAC")] IUnitOfWork uow, [Named("CADM")] IUnitOfWork cadmuow)
        {
            _uow = uow;
            _cadmuow = cadmuow;
        }
        
        public ActionResult ConfigureService(int? selectedService)
        {
            var configureService = new ConfigureServiceViewModel();

            var serviceTypes = _uow.Repository<ServiceType>().Query().Get().ToList();

            selectedService = selectedService ?? 2;

            ViewBag.SelectedService = new SelectList(serviceTypes, "ServiceId", "Name", selectedService);

            int serviceTypeId = selectedService.GetValueOrDefault();

            var service = _uow.Repository<ServiceType>().Query().Get().First(s => s.ServiceId == serviceTypeId);

            var siteName = new SqlParameter("@sitename", "CallCredit");
            var applicationName = new SqlParameter("@applicationname", service.Name);

            var siteLogin = _cadmuow.Repository<SiteLogin>()
                .SqlQuery("GetSiteLogin @sitename, @applicationname", siteName, applicationName).First();

            configureService.ServiceTypes = serviceTypes;
            configureService.Company = service.Company;
            configureService.SiteLogin = siteLogin;

            return View(configureService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfigureService(ConfigureServiceViewModel servicedata, int? selectedService)
        {
            var service = _uow.Repository<ServiceType>().Query().Get().First(s => s.ServiceId == selectedService);

            var siteName = new SqlParameter("@sitename", "CallCredit");
            var applicationName = new SqlParameter("@applicationname", service.Name);

            SiteLogin siteLogin;
            try
            {
                siteLogin = _cadmuow.Repository<SiteLogin>()
                    .SqlQuery("GetSiteLogin @sitename, @applicationname", siteName, applicationName).FirstOrDefault();

                siteLogin = servicedata.SiteLogin;
                siteLogin.ObjectState = ObjectState.Modified;
                _cadmuow.Save();
            }
            catch (Exception Ex)
            {
            }
            
            service.Company = servicedata.Company;
            _uow.Save();

            return RedirectToAction("ConfigureService", selectedService);
        }

        public ActionResult ServiceDetails(int serviceId)
        {
            var configureService = new ConfigureServiceViewModel();

            var serviceTypes = _uow.Repository<ServiceType>().Query().Get().ToList();

            var service = _uow.Repository<ServiceType>().Query().Get().First(s => s.ServiceId == serviceId);

            var siteName = new SqlParameter("@sitename", "CallCredit");
            var applicationName = new SqlParameter("@applicationname", service.Name);

            var siteLogin = _cadmuow.Repository<SiteLogin>()
                .SqlQuery("GetSiteLogin @sitename, @applicationname", siteName, applicationName).First();

            configureService.ServiceTypes = serviceTypes;
            configureService.Company = service.Company;
            configureService.SiteLogin = siteLogin;

            return Json(configureService, JsonRequestBehavior.AllowGet);
        }
    }
}