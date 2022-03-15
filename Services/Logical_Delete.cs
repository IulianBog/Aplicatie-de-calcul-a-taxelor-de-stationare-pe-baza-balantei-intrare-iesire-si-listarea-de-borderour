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
    public class Logical_Delete
    {
        readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;

        public void Delete_Transactions(TransactionModel transactionModel , List<TransactionModel> transactions)
        {

            using OracleConnection con = new OracleConnection(conString);
            {
                foreach (var i in transactions)
                {
                    sqlStatement = "UPDATE C##TAXARE1.TRANSACTION SET  C##TAXARE1.TRANSACTION.IS_DELETED = 1 " +
                       "WHERE C##TAXARE1.TRANSACTION.ID =  :Transaction_Id";

                    OracleCommand cmd = new OracleCommand(sqlStatement, con);
                    cmd.Parameters.Add(new OracleParameter("Transaction_Id", transactionModel.Id));

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
}
