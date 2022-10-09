using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class PlantItemDTO
    {
        public string SP_ID { get; set; }
        public string Name { get; set; }
        public string ItemTag { get; set; }
        public int PlantItemType { get; set; }
        public int TagReqdFlag { get; set; }
        public string aabbcc_code { get; set; }
        public int FabricationCategory { get; set; }
        public string SP_PartOfID { get; set; }
        public string SP_PlantGroupID { get; set; }
        public int SupplyBy { get; set; }
        public int RequisitionBy { get; set; }
        public string SP_RelationImpliedID { get; set; }
        public int PartOfType { get; set; }
        public int IsBulkItem { get; set; }
        public string InventoryTag { get; set; }
        public int ConstructionStatus { get; set; }
        public int ConstructionBy { get; set; }

        public PlantItemDTO()
        {
        }
    }
}