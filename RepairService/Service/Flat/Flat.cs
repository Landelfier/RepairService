using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class Flat
    {
        public Flat()
        {
            //Additionals = new List<AdditionalsFlat>(); 
        }
        public int ID { get; set; }
        public virtual User User { get; set; }
        public int Square { get; set; }
        public int RoomNumber { get; set; }
        public int DoorNumber { get; set; }
        public int Height { get; set; }
        public string Address { get; set; }
        public virtual List<AdditionalsFlat> Additionals { get; set; }
        public virtual BaseSettings Bathroom { get; set; }
        public virtual RoomSettings Rooms { get; set; }
        public virtual BaseSettings Kitchen { get; set; }
    }
}
