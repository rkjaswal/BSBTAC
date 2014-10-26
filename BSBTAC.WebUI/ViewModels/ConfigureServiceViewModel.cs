using BSBTAC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSBTAC.WebUI.ViewModels
{
    public class ConfigureServiceViewModel
    {
        public virtual IEnumerable<ServiceType> ServiceTypes { get; set; }
        public virtual SiteLogin SiteLogin { get; set; }
        public string Company { get; set; }
    }
}