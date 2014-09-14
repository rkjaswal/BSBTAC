using Common.DAL;
using System;
using System.Collections.Generic;

namespace BSBTAC.Domain.Models
{
    public partial class UploadDetail : EntityBase
    {
        public int UploadDetailId { get; set; }
        public string Filename { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public string UploadedBy { get; set; }
        public Nullable<System.DateTime> UploadDatetime { get; set; }
    }
}
