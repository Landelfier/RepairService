using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class AdditionalOptions
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        [JsonIgnore]
        public virtual List<AdditionalsFlat> AdditionalsFlats { get; set; }
    }
}
