using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class RepairSettingModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> ColorList { get; set; }
    }
}
