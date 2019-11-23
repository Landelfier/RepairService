using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public enum MaterialPurpose { Walls,Doors,Floor,Baseboard,PowerSockets }
    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<MaterialColors> MaterialColors { get; set; }
        public virtual List<RoomSettings> Doors { get; set; }
        public virtual List<RoomSettings> Walls { get; set; }
        public virtual List<RoomSettings> Floors { get; set; }
        public virtual List<RoomSettings> Baseboards { get; set; }
        public virtual List<RoomSettings> PowerSockets { get; set; }
        public string Cost { get; set; }
        public MaterialPurpose Purpose { get; set; }
    }
}
