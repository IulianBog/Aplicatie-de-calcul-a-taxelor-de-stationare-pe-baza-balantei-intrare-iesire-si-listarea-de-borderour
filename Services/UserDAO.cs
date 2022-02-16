using Proiect.Models;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;




namespace Proiect.Services
{
    public class UserDAO
    {
       readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool succes = false;

            using (OracleConnection con = new OracleConnection(conString))
            {
                
                    sqlStatement = "SELECT * FROM C##TAXARE1.USERS WHERE C##TAXARE1.USERS.NICKNAME = :username AND C##TAXARE1.USERS.PASSWORD = :password";
                    OracleCommand cmd = new OracleCommand(sqlStatement,con);
                    
                    cmd.Parameters.Add(new OracleParameter("username",user.UserName));
                    cmd.Parameters.Add(new OracleParameter("password", user.Password));
                    cmd.Parameters.Add(new OracleParameter("ID", user.Id));

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        succes = true;
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

            return succes;

        }
                

    }
}

