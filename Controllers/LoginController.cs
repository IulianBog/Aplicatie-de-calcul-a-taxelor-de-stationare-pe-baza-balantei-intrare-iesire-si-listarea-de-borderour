using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models;
using Proiect.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    public class LoginController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProcessLogin(UserModel userModel)
        {
            
            SecurityService securityService = new SecurityService();

            int user_id = securityService.IsValid(userModel);

            if (user_id != 0)
            {
                HttpContext.Session.SetString("User_Id", user_id.ToString());
                HttpContext.Session.SetString("User", userModel.UserName);

                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(UserModel userModel)
        {
            ViewBag.user = HttpContext.Session.GetString("User");
            ViewBag.session = HttpContext.Session.GetString("User_Id");
            UserDAO userDAO = new UserDAO();
            userModel.UserName = userDAO.ChangePassword_Validation(userModel, ViewBag.session);
            return View();
        }

        public IActionResult Update(UserModel userModel)
        {
            ViewBag.user = HttpContext.Session.GetString("User");
            ViewBag.session = HttpContext.Session.GetString("User_Id");
            if (userModel.UserName == ViewBag.user)
            {
                UserDAO userDAO = new UserDAO();
                userDAO.ChangePassword(userModel, ViewBag.session);

                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("Edit");
            }
        }

        




    }
}
