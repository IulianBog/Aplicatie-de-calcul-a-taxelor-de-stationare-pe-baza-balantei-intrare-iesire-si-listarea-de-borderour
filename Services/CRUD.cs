using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt.Pipes;
using Microsoft.AspNetCore.Http;
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

            public CollectionDataModel Update_Transactions(CollectionDataModel col)
            {
                CollectionDataModel result = new CollectionDataModel();
                using OracleConnection con = new OracleConnection(conString);
                {

                    OracleConnection conn = new OracleConnection(conString);
                    OracleCommand cmd = new OracleCommand("CRUD_Transact_U", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pID", OracleDbType.Int32).Value = col.Id;
                    cmd.Parameters.Add("pSENS", OracleDbType.Varchar2).Value = col.Sens == "Sosiri" ? "1" : "2";
                    cmd.Parameters.Add("pDATE_TIME", OracleDbType.Date).Value = Convert.ToDateTime(col.Date_Time);
                    cmd.Parameters.Add("pTRAIN_NUMBER", OracleDbType.Varchar2).Value = col.Train_Number;
                    cmd.Parameters.Add("pVAGON_NUMBER", OracleDbType.Int32).Value = col.Vagon_Number;
                    cmd.Parameters.Add("pUSER_ID", OracleDbType.Int32).Value = col.User_Id;
                    cmd.Parameters.Add("pOTF_ID", OracleDbType.Varchar2).Value = col.OTF_Id;
                    cmd.Parameters.Add("pSTATION_ID", OracleDbType.Varchar2).Value = col.Station_Id.ToString();
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result.Message = "success";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        result.Message = "Error:" + e.Message.ToString();
                    }

                    finally
                    {
                        if (null != con)
                            con.Close();
                    }

                }
                return result;
            }

            public CollectionDataModel Delete_Transactions(CollectionDataModel col)
            {
                CollectionDataModel result = new CollectionDataModel();
                using OracleConnection conn = new OracleConnection(conString);
                {
                    OracleCommand cmd = new OracleCommand("CRUD_Transact_D", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pID", OracleDbType.Int32).Value = col.Id;
                    cmd.Parameters.Add("pUSER_ID", OracleDbType.Int32).Value = col.User_Id;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result.Message = "success";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        result.Message = "Error:" + e.Message.ToString();
                    }

                    finally
                    {
                        if (null != conn)
                            conn.Close();
                    }

                }
                return result;
            }
            public CollectionDataModel Create_Transactions(CollectionDataModel col)
            {
                CollectionDataModel result = new CollectionDataModel();
                using OracleConnection con = new OracleConnection(conString);
                {
                    try
                    {

                        OracleConnection conn = new OracleConnection(conString);
                        OracleCommand cmd = new OracleCommand("CRUD_Transact_C", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("pSENS", OracleDbType.Varchar2).Value = col.Sens == "Sosiri" ? "1" : "2";
                        cmd.Parameters.Add("pDATE_TIME", OracleDbType.Date).Value = Convert.ToDateTime(col.Date_Time);
                        cmd.Parameters.Add("pTRAIN_NUMBER", OracleDbType.Varchar2).Value = col.Train_Number;
                        cmd.Parameters.Add("pVAGON_NUMBER", OracleDbType.Int32).Value = col.Vagon_Number;
                        cmd.Parameters.Add("pUSER_ID", OracleDbType.Int32).Value = col.User_Id;
                        cmd.Parameters.Add("pOTF_ID", OracleDbType.Varchar2).Value = col.OTF_Id;
                        cmd.Parameters.Add("pSTATION_ID", OracleDbType.Varchar2).Value = col.Station_Id.ToString();
                        cmd.Parameters.Add("pMySeq", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result.Id = Convert.ToInt32(cmd.Parameters["pMySeq"].Value.ToString());
                        result.Message = "success";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        result.Message = "Error:" + e.Message.ToString();
                    }

                    finally
                    {
                        if (null != con)
                            con.Close();

                    }

                }
                return result;
            }

            public CollectionDataModel validate_transaction(CollectionDataModel col)
            {
                CollectionDataModel result = new CollectionDataModel();
                using OracleConnection con = new OracleConnection(conString);
                {
                    try
                    {
                        OracleConnection conn = new OracleConnection(conString);
                        OracleCommand cmd = new OracleCommand("validate_transaction", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_otf_id", OracleDbType.Char).Value = col.OTF_Id;
                        cmd.Parameters.Add("p_station_id", OracleDbType.Char).Value = col.Station_Id;
                        var dt = Convert.ToDateTime(col.Date_Time);
                        string dataa = dt.Year.ToString() + dt.ToString("MM") + dt.ToString("dd");
                        cmd.Parameters.Add("p_transaction_date", OracleDbType.Char).Value = dt;
                        //cmd.Parameters.Add("ln_aux", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result.Id = Convert.ToInt32(cmd.Parameters["ln_aux"].Value.ToString());
                        if (result.Id != 0)
                            result.Message = "success";
                        else result.Message = "NU validez - am gasit checkpoint avand data_check mai mare decat data tranzatiei curente!";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        result.Message = "Error:" + e.Message.ToString();
                    }

                    finally
                    {
                        if (null != con)
                            con.Close();

                    }

                }
                return result;
            }

        }
    }