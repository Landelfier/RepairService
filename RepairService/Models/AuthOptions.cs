using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairService
{
    public class AuthOptions
    {
        public const string ISSUER = "RepairService"; // издатель токена
        public const string AUDIENCE = "https://localhost:44305";
        public const int LIFETIME = 24; // минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            string key = "q2267wer111ty&^><|ghf3234mnhhf%09";
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}
