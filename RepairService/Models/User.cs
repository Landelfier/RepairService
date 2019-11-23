using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
