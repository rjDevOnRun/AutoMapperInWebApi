using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PlantItem
    {
        public string SP_ID { get; set; }
        public string ItemTag { get; set; }
        public int PlantItemType { get; set; }
        public string SP_PlantGroupID { get; set; }
    }
}