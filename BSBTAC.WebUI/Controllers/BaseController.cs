using Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSBTAC.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _uow;
    }
}