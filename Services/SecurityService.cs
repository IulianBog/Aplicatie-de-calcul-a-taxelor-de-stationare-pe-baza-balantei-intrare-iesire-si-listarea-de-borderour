using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Services
{


    public class SecurityService
    {
        readonly UserDAO userDAO = new UserDAO();
      

        public bool IsValid(UserModel user)
        {
            
            return userDAO.FindUserByNameAndPassword(user);

        }
    }
  
}
