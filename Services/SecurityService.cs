﻿using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Services
{


    public class SecurityService
    {
        readonly UserDAO userDAO = new UserDAO();

        public static string CreateMD5(string input)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }



        public int IsValid(UserModel user)
        {

            return userDAO.FindUserByNameAndPassword(user);

        }


    }
}