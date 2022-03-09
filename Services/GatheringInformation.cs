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

        public Dictionary<int,CheckpointModel > GetCheckpoint()
        {
            Dictionary<int,CheckpointModel> checkpoint = new Dictionary<int, CheckpointModel>();

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
                        checkpoint.Add((int)reader.GetDecimal("ID"), new CheckpointModel 
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

        public Dictionary<string,OTFModel>GetOTF()
        {
            Dictionary<string,OTFModel> otf = new Dictionary<string,OTFModel>();
            OTFModel otfmodel = new OTFModel();

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
                        otf.Add((string)reader.GetString("ID"), new OTFModel
                        {
                            Id = (string)reader.GetString("ID"),
                            Name = (string)reader.GetString("NAME"),
                            Trafic_Type_Id = (string)reader.GetString("TRAFIC_TYPE_ID")
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

                return otf;
            }
        }

        public Dictionary<string,StationModel>GetStation()
        {
            Dictionary<string,StationModel> station = new Dictionary<string,StationModel>();

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
                        station.Add((string)reader.GetString("ID"), new StationModel
                        {
                            Id = (string)reader.GetString("ID"),
                            Name = (string)reader.GetString("NAME"),
                            Taxes_Values_Id = (int)reader.GetDecimal("TAXES_VALUES_ID")
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

                return station;
            }
        }

        public Dictionary<int,Taxes_TypesModel>GetTaxes_Types()
        {
            Dictionary<int,Taxes_TypesModel> taxes_type = new Dictionary<int,Taxes_TypesModel>();

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
                        taxes_type.Add((int)reader.GetDecimal("ID"), new Taxes_TypesModel
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

        public Dictionary<int,Taxes_ValueModel>GetTaxes_Value()
        {
            Dictionary<int,Taxes_ValueModel> taxes_values = new Dictionary<int,Taxes_ValueModel>();

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
                        taxes_values.Add((int)reader.GetDecimal("ID"), new Taxes_ValueModel
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
                        trafic_type.Add((string)reader.GetString("ID"), new Trafic_TypeModel
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

        public Dictionary<int,TransactionModel>GetTransaction()
        {
            Dictionary<int,TransactionModel> transaction = new Dictionary<int,TransactionModel>();

            using (OracleConnection con = new OracleConnection(conString))
            {

                sqlStatement = "SELECT * FROM C##TAXARE1.TRANSACTION";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        transaction.Add((int)reader.GetDecimal("ID"), new TransactionModel
                        {
                            Id = (int)reader.GetDecimal("ID"),
                            Sens = (string)reader.GetString("SENS"),
                            Data_Time = (string)reader.GetString("DATA_TIME"),
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
