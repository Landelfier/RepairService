  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public enum Purpose { Kitchen,Bathroom}
    public class BaseSettings
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<SettingsColor> SettingsColors { get; set; }
        public string Cost { get; set; }
        public Purpose purpose { get; set; }
    }
}
