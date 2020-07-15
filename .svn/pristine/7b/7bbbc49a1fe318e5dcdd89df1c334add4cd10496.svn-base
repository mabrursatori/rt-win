using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Npgsql;
using rtwin.lib;

namespace rtwin.Model
{
    class login
    {
        private string username, password;
        private string query = String.Empty;
        public koneksi cn;
        public login(string username,string password,bool sqlServer)
        {
            this.username = username;
            this.password = MD5Hash(password);
            this.cn = new koneksi(sqlServer);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public string getLogin()
        {
            
            List<datakaryawan> dataKaryawan = new List<datakaryawan>();
            query = "select NIP,USERNAME,NAMA,NAMA_CABANG,KODE_LEVEL from q_users where USERNAME='" + username + "' AND PASSW='" + password + "' ";
            string temp=String.Empty;
            if (cn.sqlServer)
            {
                loginSqlServer(query, ref temp, dataKaryawan);
            }
            else
            {
                loginPostgreSql(query, ref temp, dataKaryawan);
            }
            return temp;
        }
        private void loginSqlServer(string query,ref string temp,List<datakaryawan> dataKaryawan)
        {
            SqlConnection con = new SqlConnection(cn.koneksiString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        dataKaryawan.Add(new datakaryawan { nip = sqlDataReader["NIP"].ToString(), nama = sqlDataReader["NAMA"].ToString(), namaCabang = sqlDataReader["NAMA_CABANG"].ToString(), username = sqlDataReader["USERNAME"].ToString(),gradeID=sqlDataReader["KODE_LEVEL"].ToString() });
                    }
                    cn.createLog(dataKaryawan[0].username, "0015", "");
                    temp = JsonConvert.SerializeObject(dataKaryawan);
                    
                }
                else
                {
                    temp = "Login gagal";
                }
                con.Close();
            }
            catch (SqlException e)
            {

                temp = "Login gagal";
                Console.WriteLine(e.Message);
                con.Close();
            }
        }
        private void loginPostgreSql(string query, ref string temp, List<datakaryawan> dataKaryawan)
        {
            NpgsqlConnection con = new NpgsqlConnection(cn.koneksiString);

            try
            {

                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        dataKaryawan.Add(new datakaryawan { nip = sqlDataReader["NIP"].ToString(), nama = sqlDataReader["NAMA"].ToString(), namaCabang = sqlDataReader["NAMA_CABANG"].ToString(), username = sqlDataReader["USERNAME"].ToString(), gradeID = sqlDataReader["KODE_LEVEL"].ToString() });
                    }
                    temp = JsonConvert.SerializeObject(dataKaryawan);
                }
                else
                {
                    temp = "Login gagal";
                }
                con.Close();
            }
            catch (SqlException e)
            {

                temp = "Login gagal";
                Console.WriteLine(e.Message);
                con.Close();
            }
        }
    }
}
