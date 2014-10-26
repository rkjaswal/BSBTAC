using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;

namespace BSBTAC.Domain.Models
{
    public class SiteLogin : EntityBase
    {
        [Key]
        public int SiteId { get; set; }
        public int ApplicationId { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
