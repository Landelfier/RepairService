using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class FlatModel
    {
        public string login { get; set; }
        public int square { get; set; }
        public int roomNumber { get; set; }
        public int doorNumber { get; set; }
        public int height { get; set; }
        public string address { get; set; }
        public RoomSettings rooms { get; set; }
        public int bathroomID { get; set; }
        public int kitchenID { get; set; }
        public IEnumerable<int> additionalsID { get; set; }
    }
}
