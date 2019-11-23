using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class SettingsColor
    {
        public int ID { get; set; }
        public int BaseSettingsID { get; set; }
        public virtual Color color { get; set; }
        public virtual BaseSettings BaseSettings { get; set; }
        public int ColorID { get; set; }
    }
}
