using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string First_Name { get; set; }

        public string Second_Name { get; set; }
        
        public string Roles_Id { get; set; }
        
        public string Password { get; set; }
    }
}
