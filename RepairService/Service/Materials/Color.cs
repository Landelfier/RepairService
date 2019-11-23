using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string ColorName { get; set; }
        public virtual List<MaterialColors> MaterialColors { get; set; }
    }
}
