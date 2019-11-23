using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class AdditionalsFlat
    {
        public int ID { get; set; }
        public int FlatID { get; set; }
        public virtual Flat Flat { get; set; }
        public int AdditionalOptionsID { get; set; }
        public virtual AdditionalOptions AdditionalOptions { get; set; }
    }
}
