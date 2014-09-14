using Common.DAL;
using System;
using System.Collections.Generic;

namespace BSBTAC.Domain.Models
{
    public partial class ApplSummary : EntityBase
    {
        public int ApplSummaryId { get; set; }
        public int SearchDefinitionId { get; set; }
        public string AccountInformation { get; set; }
        public Nullable<int> NumberOfDisputes { get; set; }
    }
}
