using Common.DAL;
using System;
using System.Collections.Generic;

namespace BSBTAC.Domain.Models
{
    public partial class SearchDefinition : EntityBase
    {
        public int SearchDefinitionId { get; set; }
        public Nullable<int> UploadDetailId { get; set; }
        public int DebtCode { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Othername { get; set; }
        public System.DateTime DOB { get; set; }
        public string BuildingNo { get; set; }
        public string BuildingName { get; set; }
        public string Locality { get; set; }
        public string Sublocality { get; set; }
        public string Posttown { get; set; }
        public string Postcode { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public Nullable<System.DateTime> LastUpdatedDatetime { get; set; }
        public string FailureReason { get; set; }
    }
}
