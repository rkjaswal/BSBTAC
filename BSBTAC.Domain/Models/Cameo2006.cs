using Common.DAL;
using System;
using System.Collections.Generic;

namespace BSBTAC.Domain.Models
{
    public partial class Cameo2006 : EntityBase
    {
        public int Cameo2006Id { get; set; }
        public int SearchDefinitionId { get; set; }
        public string LocalityInformation { get; set; }
        public Nullable<int> CouncilTaxBand { get; set; }
    }
}
