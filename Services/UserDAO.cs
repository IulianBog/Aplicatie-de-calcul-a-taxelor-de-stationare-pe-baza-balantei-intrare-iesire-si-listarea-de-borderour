using Proiect.Models;
using Proiect.Services;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace Proiect.Services
{
    public class UserDAO

    {
        readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;
     
       

        public int FindUserByNameAndPassword(UserModel user)
        {

            int user_id = 0;
            using (OracleConnection con = new OracleConnection(conString))
            {
                
                user.Password = SecurityService.CreateMD5(user.Password);
                
                    sqlStatement = "SELECT * FROM C##TAXARE1.USERS WHERE C##TAXARE1.USERS.NICKNAME = :username AND C##TAXARE1.USERS.PASSWORD = :password";
                    OracleCommand cmd = new OracleCommand(sqlStatement,con);
                    
                    cmd.Parameters.Add(new OracleParameter("username",user.UserName));
                    cmd.Parameters.Add(new OracleParameter("password", user.Password));

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        user.Id = (int)reader.GetDecimal("ID");
                        user.First_Name = (string)reader.GetString("FIRST_NAME");
                        user.Last_Name = (string)reader.GetString("LAST_NAME");
                        user.Roles_Id = (int)reader.GetDecimal("ROLES_ID");

                        user_id = user.Id;
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    if (null != con)
                        con.Close();
                }
            }

            return user_id;

        }

        public string ChangePassword_Validation(UserModel user, string user_id)
        {
            using OracleConnection con = new OracleConnection(conString);

            sqlStatement = "SELECT * FROM C##TAXARE1.USERS" +
                "WHERE C##TAXARE1.USERS.ID =  :user_id";
            OracleCommand cmd = new OracleCommand(sqlStatement, con);
            cmd.Parameters.Add(new OracleParameter("user_id", user_id));
            try
            {
                con.Open();
                cmd.BindByName = true;
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.UserName = (string)reader.GetString("NICKNAME");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (null != con)
                    con.Close();
            }

            return user.UserName;
        }
       public void ChangePassword(UserModel user, string user_id)
        {


            using OracleConnection con = new OracleConnection(conString);
            user.Password = SecurityService.CreateMD5(user.Password);

            sqlStatement = "UPDATE C##TAXARE1.USERS SET  C##TAXARE1.USERS.PASSWORD = :password " +
                "WHERE C##TAXARE1.USERS.ID =  :user_id";

            OracleCommand cmd = new OracleCommand(sqlStatement, con);
            cmd.Parameters.Add(new OracleParameter("user_id", user_id));
            cmd.Parameters.Add(new OracleParameter("password", user.Password));

            try
            {
                con.Open();
                cmd.BindByName = true;
                OracleDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (null != con)
                    con.Close();
            }

        }

        
    }
}

