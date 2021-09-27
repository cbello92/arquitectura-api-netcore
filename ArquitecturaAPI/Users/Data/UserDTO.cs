using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArquitecturaAPI.Users.Data
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Email { get; set; }
    }
}
