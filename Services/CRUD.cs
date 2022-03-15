using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt.Pipes;
using Oracle.ManagedDataAccess.Client;
using Proiect.Models;

namespace Proiect.Services
{
    public class CRUD
    {
        readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;


       /* public void Create_Transactions(int id)
        {
            using OracleConnection con = new OracleConnection(conString);
            {
                sqlStatement = "UPDATE C##TAXARE1.TRANSACTION SET  C##TAXARE1.TRANSACTION.IS_DELETED = 1 " +
                               "WHERE C##TAXARE1.TRANSACTION.ID =  :Transaction_Id";

                OracleCommand cmd = new OracleCommand(sqlStatement, con);
                cmd.Parameters.Add(new OracleParameter("Transaction_Id", id));

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
       */

        public void Update_Transactions(int id)
        {
            TransactionModel transaction = new TransactionModel();
            using OracleConnection con = new OracleConnection(conString);
            {
                sqlStatement = "UPDATE C##TAXARE1.TRANSACTION SET C##TAXARE1.TRANSACTION.SENS = :transaction.sens " +
                               ",  C##TAXARE1.TRANSACTION.DATE_TIME = :transaction.date_time" +
                               ",  C##TAXARE1.TRANSACTION.TRAIN_NUMBER = :transaction.train_number" +
                               ",  C##TAXARE1.TRANSACTION.VAGON_NUMBER = :transaction.vagon.number" +
                               "WHERE C##TAXARE1.TRANSACTION.ID =  :Transaction_Id";

                OracleCommand cmd = new OracleCommand(sqlStatement, con);
                cmd.Parameters.Add(new OracleParameter("transaction.date_time",transaction.Date_Time));
                cmd.Parameters.Add(new OracleParameter("transaction.sens", transaction.Sens));
                cmd.Parameters.Add(new OracleParameter("transaction.train_number", transaction.Train_Number));
                cmd.Parameters.Add(new OracleParameter("transaction.vagon_number", transaction.Vagon_Number));
                cmd.Parameters.Add(new OracleParameter("Transaction_Id", id));

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

        public void Delete_Transactions(int id)
        {

            using OracleConnection con = new OracleConnection(conString);
            { 
                    sqlStatement = "UPDATE C##TAXARE1.TRANSACTION SET  C##TAXARE1.TRANSACTION.IS_DELETED = 1 " +
                                   "WHERE C##TAXARE1.TRANSACTION.ID =  :Transaction_Id";

                    OracleCommand cmd = new OracleCommand(sqlStatement, con);
                    cmd.Parameters.Add(new OracleParameter("Transaction_Id", id));

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
}
