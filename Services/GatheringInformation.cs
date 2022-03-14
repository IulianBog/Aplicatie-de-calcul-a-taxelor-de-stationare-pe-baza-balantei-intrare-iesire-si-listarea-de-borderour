using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using Oracle.ManagedDataAccess.Client;
using Proiect.Models;

namespace Proiect.Services
{
    public class GatheringInformation
    {
        readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;

        public Dictionary<string,CheckpointModel > GetCheckpoint()
        {
            Dictionary<string,CheckpointModel> checkpoint = new Dictionary<string, CheckpointModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {
                sqlStatement = "SELECT * FROM C##TAXARE1.CHECKPOINT";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        checkpoint.Add("Checkpoint", new CheckpointModel 
                        { 
                           Id = (int)reader.GetDecimal("ID"), 
                           Balance_Wagons = (int)reader.GetDecimal("BALANCE_WAGONS"),
                           Data_Check = (string)reader.GetString("DATA_CHECK"),
                           Transaction_Id = (int)reader.GetDecimal("TRANSACTION_ID") 
                        });
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

                return checkpoint;
            }
        }

        public Dictionary<string,string> GetOTF()
            {
                Dictionary<string, string> otf = new Dictionary<string, string>();

                using (OracleConnection con = new OracleConnection(conString))
                 {
                    sqlStatement = "SELECT * FROM C##TAXARE1.OTF";
                    OracleCommand cmd = new OracleCommand(sqlStatement, con);

                    try
                    {
                        con.Open();
                        cmd.BindByName = true;
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                        otf.Add((string)reader.GetString("ID"),
                            (string)reader.GetString("NAME"));
                            
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

                    return otf;
                }
            }
        /*   
       public OTFModel GetOTF()
       {
           OTFModel otf = new OTFModel();

           using (OracleConnection con = new OracleConnection(conString))
           {
               sqlStatement = "SELECT * FROM C##TAXARE1.OTF";
               OracleCommand cmd = new OracleCommand(sqlStatement, con);

               try
               {
                   con.Open();
                   cmd.BindByName = true;
                   OracleDataReader reader = cmd.ExecuteReader();

                   while (reader.Read())
                   {


                       otf.Id = (string)reader.GetString("ID");
                       otf.Name = (string)reader.GetString("NAME");
                       otf.Trafic_Type_Id = (string)reader.GetString("TRAFIC_TYPE_ID");
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

               return otf;
           }
       }*/


        public Dictionary<string,string>GetStation()
        {
            Dictionary<string,string> station = new Dictionary<string,string>();

            using (OracleConnection con = new OracleConnection(conString))
            {
                sqlStatement = "SELECT * FROM C##TAXARE1.STATION";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        station.Add((string)reader.GetString("ID"),
                            (string)reader.GetString("NAME"));
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

                return station;
            }
        }

        public Dictionary<string,Taxes_TypesModel>GetTaxes_Types()
        {
            Dictionary<string,Taxes_TypesModel> taxes_type = new Dictionary<string,Taxes_TypesModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {
                sqlStatement = "SELECT * FROM C##TAXARE1.TAXES_TYPES";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        taxes_type.Add("Taxes_Types", new Taxes_TypesModel
                        {
                            Id = (int)reader.GetDecimal("ID"),
                            Description = (string)reader.GetString("DESCRIPTION")
                        });
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

                return taxes_type;
            }
        }

        public Dictionary<string,Taxes_ValueModel>GetTaxes_Value()
        {
            Dictionary<string,Taxes_ValueModel> taxes_values = new Dictionary<string,Taxes_ValueModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {

                sqlStatement = "SELECT * FROM C##TAXARE1.TAXES_VALUES";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        taxes_values.Add("Taxes_Value", new Taxes_ValueModel
                        {
                            Id = (int)reader.GetDecimal("ID"),
                            Date_To_Start = (string)reader.GetString("DATE_TO_START"),
                            CT1_C = (float)reader.GetFloat("CT1_C"),
                            CT2_C = (float)reader.GetFloat("CT2_C"),
                            CT1_M = (float)reader.GetFloat("CT1_M"),
                            CT2_M = (float)reader.GetFloat("CT2_M"),
                            Taxes_Types_Id = (int)reader.GetDecimal("TAXES_TYPES_ID")
                    });
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

                return taxes_values;
            }
        }

        public Dictionary<string,Trafic_TypeModel>GetTrafic_Type()
        {
            Dictionary<string,Trafic_TypeModel> trafic_type = new Dictionary<string,Trafic_TypeModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {

                sqlStatement = "SELECT * FROM C##TAXARE1.TRAFIC_TYPE";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        trafic_type.Add("Trafic_Type", new Trafic_TypeModel
                        {
                            Id = (string)reader.GetString("ID"),
                            Name = (string)reader.GetString("NAME")
                        });
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

                return trafic_type;
            }
        }

        public List<TransactionModel>GetTransaction()
        {
            List<TransactionModel> transaction = new List<TransactionModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {

                sqlStatement = "SELECT * FROM C##TAXARE1.TRANSACTION";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        transaction.Add(new TransactionModel
                        {
                            Id = (int)reader.GetDecimal("ID"),
                            Sens = (string)reader.GetString("SENS"),
                            Date_Time = (string)reader.GetString("DATE_TIME"),
                            Train_Number = (string)reader.GetString("TRAIN_NUMBER"),
                            Vagon_Number = (int)reader.GetDecimal("VAGON_NUMBER"),
                            Time_Stamp = (DateTime)reader.GetDateTime("TIME_STAMP"),
                            User_Id = (int)reader.GetDecimal("USER_ID"),
                            OTF_Id = (string)reader.GetString("OTF_ID"),
                            Station_Id = (string)reader.GetString("Station_ID")
                        });
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

                return transaction;
            }
        }

    }
}
