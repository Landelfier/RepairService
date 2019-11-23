using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class MaterialColors
    {
        public int ID { get; set; }
        public int MaterialID { get; set; }
        public virtual Color color { get; set; }
        public virtual Material Material { get; set; } 
        public int ColorID { get; set; }
    }
}
