using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Proiect.Models;

namespace Proiect.Services
{
    public class Borderouri
    {
        readonly string conString = "User Id=C##TAXARE1;Password=123456;Data Source=localhost:1521/xe;Connection Timeout=30;";
        private string sqlStatement;

        public CollectionDataModel Gen_Pret_Unitar(CollectionDataModel col)
        {
            CollectionDataModel result = new CollectionDataModel();
            using OracleConnection con = new OracleConnection(conString);
            {

                OracleConnection conn = new OracleConnection(conString);
                OracleCommand cmd = new OracleCommand("get_pret_unitar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_otf_id", OracleDbType.Varchar2).Value = col.OTF_Id;
                cmd.Parameters.Add("p_station_id", OracleDbType.Varchar2).Value = col.Station_Id;
                cmd.Parameters.Add("p_transaction_date", OracleDbType.Char).Value = Convert.ToDateTime(col.Date_Time);


                conn.Open();
                cmd.ExecuteNonQuery();

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
        
        public CollectioDataModel_Bor Gen_Bord(CollectioDataModel_Bor col) //********
        {
            CollectioDataModel_Bor result = new CollectioDataModel_Bor();
            using OracleConnection con = new OracleConnection(conString);

            {

                OracleConnection conn = new OracleConnection(conString);
                OracleCommand cmd = new OracleCommand("GEN_BORDEROU", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_OTF_ID", OracleDbType.Varchar2).Value = col.OTF_Id_Bor;
                cmd.Parameters.Add("p_STATION_ID", OracleDbType.Varchar2).Value = col.Station_Id_Bor;
                cmd.Parameters.Add("p_data_chk", OracleDbType.Varchar2).Value = Convert.ToDateTime(col.DateTime_Bor);
                cmd.Parameters.Add("p_set_chk", OracleDbType.Varchar2).Value = "N" ;
                cmd.Parameters.Add("p_sess_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                
                conn.Open();
                cmd.ExecuteNonQuery();
                result.Id_Sesiune_Bor = Convert.ToInt32(cmd.Parameters["p_sess_id"].Value.ToString());


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


        public CollectionDataModel Get_Last_Checkpoint(CollectionDataModel col)
        {
            CollectionDataModel result = new CollectionDataModel();
            using OracleConnection con = new OracleConnection(conString);

            {

                OracleConnection conn = new OracleConnection(conString);
                OracleCommand cmd = new OracleCommand("GET_LAST_CHECKPOINT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_otf_id", OracleDbType.Char).Value = col.OTF_Id;
                cmd.Parameters.Add("p_station_id", OracleDbType.Char).Value = col.Station_Id;
                cmd.Parameters.Add("p_transaction_date", OracleDbType.Char).Value = Convert.ToDateTime(col.Date_Time);
                var dt = Convert.ToDateTime(col.Date_Time);
                string dataa = dt.Year.ToString() + dt.ToString("MM") + dt.ToString("dd");
                cmd.Parameters.Add("p_transaction_date", OracleDbType.Char).Value = dt;

                conn.Open();
                cmd.ExecuteNonQuery();
                result.Id = Convert.ToInt32(cmd.Parameters["ln_aux"].Value.ToString());

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


        public List<Bord> GetBorderouri()
        {
            List<Bord> transaction = new List<Bord>();

            using (OracleConnection con = new OracleConnection(conString))
            {

                sqlStatement = "SELECT * FROM C##TAXARE1.TMP_BORDEROURI order by DATA_ORA ASC";
                OracleCommand cmd = new OracleCommand(sqlStatement, con);

                try
                {
                    con.Open();
                    cmd.BindByName = true;
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        transaction.Add(new Bord
                        {
                            Sess_Id = reader.GetInt32("SESS_ID"),
                            Ordine = reader.GetInt32("ORDINE"),
                            Data_Ora = Convert.ToDateTime(reader.GetDateTime("DATA_ORA")),
                            Sold_Ini = reader.GetInt32("SOLD_UNI"),
                            Vag_In = reader.GetInt32("VAG_IN"),
                            Vag_Out = reader.GetInt32("VAG_OUT"),
                            Vag_Ore = reader.GetInt32("VAG_ORE"),
                            Sold_Fin = reader.GetInt32("SOLD_FIN"),
                            Pret_Unitar = reader.GetInt32("PRET_UNITAR"),
                            Valoare = reader.GetInt32("VALOARE"),
                            OTF_Id = reader.GetString("OTF_ID"),
                            Station_Id = reader.GetString("Station_ID")

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
