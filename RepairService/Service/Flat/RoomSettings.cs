using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    [Bind("WallsID", "DoorsID", "FloorID", "BaseboardID", "PowerSocketsID")]
    public class RoomSettings
    {
        public int ID { get; set; }
        [JsonIgnore]
        public virtual Material Walls { get; set; }
        public int WallsID { get; set; }
        [JsonIgnore]
        public virtual Material Doors { get; set; }
        public int DoorsID { get; set; }
        [JsonIgnore]
        public virtual Material Floor { get; set; }
        public int FloorID { get; set; }
        [JsonIgnore]
        public virtual Material Baseboard { get; set; }
        public int BaseboardID { get; set; }
        [JsonIgnore]
        public virtual Material PowerSockets { get; set; }
        public int PowerSocketsID { get; set; }
    }
}
