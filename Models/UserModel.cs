using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }
        
        public int Roles_Id { get; set; }

        public string Password { get; set; }
    }
}
