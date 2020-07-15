using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Npgsql;

namespace rtwin.lib
{
    class  koneksi
    {
        public string  koneksiString=String.Empty;
        //public static SqlConnection con = new SqlConnection(koneksiString);
        public bool sqlServer;

        public koneksi(bool sqlServer) 
        {
            this.sqlServer = sqlServer;
            if (sqlServer)
            {
                //this.koneksiString = "Data Source=192.168.1.109;Initial Catalog = DataReal; User ID = rekabio; Password=Meinardi";
                this.koneksiString = @"Data Source=DESKTOP-UR1AR16\SQLEXPRESS;Initial Catalog = DataRekabio; User ID= sa; Password=saadmin";
            }
        }
        private void getDataFromSqlServer(ref List<string> dataList,string query)
        {
            SqlConnection con = new SqlConnection(koneksiString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        int field = data.FieldCount;
                        for (int i = 0; i < field; i++)
                        {
                            dataList.Add(data[i].ToString());
                        }
                    }
                }
                //else
                //{
                //    dataList.Add("0");
                //}
                data.Close();
                con.Close();
            }
            catch (SqlException e)
            {
                dataList.Add(e.Message.ToString());
                con.Close();
            }
        }
        private void getDataFromPostgreSql(ref List<string> dataList,string query)
        {
            NpgsqlConnection con = new NpgsqlConnection(koneksiString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            try
            {
                con.Open();
                NpgsqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        int field = data.FieldCount;
                        for (int i = 0; i < field; i++)
                        {
                            dataList.Add(data[i].ToString());
                        }
                    }
                }
                else
                {
                    dataList.Add("0");
                }
                data.Close();
                con.Close();
            }catch(SqlException e)
            {
                dataList.Add(e.Message.ToString());
                con.Close();
            }
        }
        public List<string> getDataFromDatabase(string query)
        {
            List<string> dataList = new List<string>();
            if (sqlServer)
            {
                getDataFromSqlServer(ref dataList, query);
            }
            else
            {
                getDataFromPostgreSql(ref dataList, query);
            }
            return dataList;
        }
        
        public string crudDatabase(string query,string messageSucces,string messageFailed)
        {
            string message = "";
            if (sqlServer)
            {
                message = crudDatabaseSqlServer(query,messageSucces,messageFailed);
            }
            else
            {
                message = crudDatabasePostgreSql(query,messageSucces, messageFailed);
            }
            return message;
        }
        private string crudDatabaseSqlServer(string query,string messageSucces,string messageFailed)
        {
            string message = String.Empty;
            SqlConnection con = new SqlConnection(koneksiString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                message = messageSucces;
                Console.WriteLine(query);
            }catch(SqlException exc)
            {
                message = messageFailed+" , "+ exc.Message.ToString();
                // message = query;
                Console.WriteLine(query);
                con.Close();
            }
            return message;
        }
        private string crudDatabasePostgreSql(string query,string messageSucces, string messageFailed)
        {
            string message = String.Empty;
            NpgsqlConnection con = new NpgsqlConnection(koneksiString);
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                message = messageSucces;
            }catch(SqlException exc)
            {
                message = messageFailed + " , " + exc.Message.ToString();
                con.Close();
            }
            return message;
        }

        public void createLog(string UserID, string ActID, string StrTarget )
        {
            string query = "INSERT INTO taLog VALUES ('RTE', '" + DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToLongTimeString() + "','" + UserID + "','" + ActID + "',LEFT('" + StrTarget + "',50))";
            crudDatabase(query, "Data Log Berhasil di Input", "Data Log gagal Di Input");

        }

    }
}
