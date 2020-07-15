using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.lib
{
    class data_report
    {

        public DataTable dataMonthlyReport(string filterdata)
        {
            string json = String.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("NIP", typeof(string));
            dt.Columns.Add("NAMA", typeof(string));
            dt.Columns.Add("TGL_MASUK", typeof(string));
            dt.Columns.Add("JAM_AWAL", typeof(string));
            dt.Columns.Add("JAM_AKHIR", typeof(string));
            dt.Columns.Add("JAM_MASUK", typeof(string));
            dt.Columns.Add("TERLAMBAT", typeof(string));
            dt.Columns.Add("JAM_KELUAR", typeof(string));
            dt.Columns.Add("CEPAT_PULANG", typeof(string));
            dt.Columns.Add("KET_SINGKAT", typeof(string));
            dt.Columns.Add("KET_POTONGAN", typeof(string));
            dt.Columns.Add("PERSEN_POTONGAN", typeof(string));
            dt.Columns.Add("UANG_MAKAN", typeof(string));
            dt.Columns.Add("NAMA_DEPARTEMEN", typeof(string));
            dt.Columns.Add("NAMA_JABATAN", typeof(string));

            DataRow dr;
            string query = queryReporting.queryMonthlyParams(filterdata);
            //MessageBox.Show(query);
            generateJson js = new generateJson(true);
            json = js.generateDataJson(query);
            List<dataMonthlyReport> data = JsonConvert.DeserializeObject<List<dataMonthlyReport>>(json);
            for (int i = 0; i < data.Count; i++)
            {
                dr = dt.NewRow();
                dr["NIP"] = data[i].NIP.ToString();
                dr["NAMA"] = data[i].NAMA.ToString();
                dr["TGL_MASUK"] = Convert.ToDateTime(data[i].TGL_MASUK).ToString("dd/MM/yyyy");
                dr["JAM_AWAL"] = Convert.ToDateTime(data[i].JAM_AWAL).ToString("HH:mm");
                dr["JAM_AKHIR"] = Convert.ToDateTime(data[i].JAM_AKHIR).ToString("HH:mm");
                dr["JAM_MASUK"] = Convert.ToDateTime(data[i].JAM_MASUK).ToString("HH:mm");
                dr["TERLAMBAT"] = Convert.ToDateTime(data[i].TERLAMBAT).ToString("HH:mm");
                dr["JAM_KELUAR"] = Convert.ToDateTime(data[i].JAM_KELUAR).ToString("HH:mm");
                dr["CEPAT_PULANG"] = Convert.ToDateTime(data[i].CEPAT_PULANG).ToString("HH:mm");
                dr["KET_SINGKAT"] = data[i].KET_SINGKAT.ToString();
                if (data[i].KET_POTONGAN == null)
                {
                    dr["KET_POTONGAN"] = "";
                }
                else
                    dr["KET_POTONGAN"] = data[i].KET_POTONGAN.ToString();
                if (data[i].PERSEN_POTONGAN == null)
                {
                    dr["PERSEN_POTONGAN"] = "";
                }
                else
                    dr["PERSEN_POTONGAN"] = data[i].PERSEN_POTONGAN.ToString();
                if (data[i].UANG_MAKAN == null)
                {
                    dr["UANG_MAKAN"] = "0";
                }
                else
                    dr["UANG_MAKAN"] = data[i].UANG_MAKAN.ToString();
                if (data[i].NAMA_DEPARTEMEN == null)
                {
                    dr["NAMA_DEPARTEMEN"] = "";
                }
                else
                    dr["NAMA_DEPARTEMEN"] = data[i].NAMA_DEPARTEMEN.ToString();
                if (data[i].NAMA_JABATAN == null)
                {
                    dr["NAMA_JABATAN"] = "";
                }
                else
                    dr["NAMA_JABATAN"] = data[i].NAMA_JABATAN.ToString();
                
                dt.Rows.Add(dr);
            }
            return dt;
            
        }

        public DataTable dataDailyReport(string filterdata)
        {
            string json = String.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("NIP", typeof(string));
            dt.Columns.Add("NAMA", typeof(string));
            dt.Columns.Add("TGL_MASUK", typeof(string));
            dt.Columns.Add("JAM_AWAL", typeof(string));
            dt.Columns.Add("JAM_AKHIR", typeof(string));
            dt.Columns.Add("JAM_MASUK", typeof(string));
            dt.Columns.Add("TERLAMBAT", typeof(string));
            dt.Columns.Add("JAM_KELUAR", typeof(string));
            dt.Columns.Add("CEPAT_PULANG", typeof(string));
            dt.Columns.Add("LEMBUR", typeof(string));
            dt.Columns.Add("KETERANGAN", typeof(string));
            dt.Columns.Add("NAMA_CABANG", typeof(string));
            dt.Columns.Add("NAMA_ESELON", typeof(string));

            DataRow dr;
            string query = queryReporting.queryDailyParams(filterdata);
            //MessageBox.Show(query);
            generateJson js = new generateJson(true);
            json = js.generateDataJson(query);
            List<dataDailyReport> data = JsonConvert.DeserializeObject<List<dataDailyReport>>(json);
            for (int i = 0; i < data.Count; i++)
            {
                dr = dt.NewRow();
                dr["NIP"] = data[i].NIP.ToString();
                dr["NAMA"] = data[i].NAMA.ToString();
                dr["TGL_MASUK"] = Convert.ToDateTime(data[i].TGL_MASUK).ToString("dd/MM/yyyy");
                dr["JAM_AWAL"] = Convert.ToDateTime(data[i].JAM_AWAL).ToString("HH:mm");
                dr["JAM_AKHIR"] = Convert.ToDateTime(data[i].JAM_AKHIR).ToString("HH:mm");
                dr["JAM_MASUK"] = Convert.ToDateTime(data[i].JAM_MASUK).ToString("HH:mm");
                dr["TERLAMBAT"] = Convert.ToDateTime(data[i].TERLAMBAT).ToString("HH:mm");
                dr["JAM_KELUAR"] = Convert.ToDateTime(data[i].JAM_KELUAR).ToString("HH:mm");
                dr["CEPAT_PULANG"] = Convert.ToDateTime(data[i].CEPAT_PULANG).ToString("HH:mm");
                if (data[i].LEMBUR == null)
                {
                    dr["LEMBUR"] = "";
                }
                else
                    dr["LEMBUR"] = data[i].LEMBUR.ToString();
                if (data[i].KETERANGAN == null)
                {
                    dr["KETERANGAN"] = "";
                }
                else
                    dr["KETERANGAN"] = data[i].KETERANGAN.ToString();
                if (data[i].NAMA_CABANG == null)
                {
                    dr["NAMA_CABANG"] = "0";
                }
                else
                    dr["NAMA_CABANG"] = data[i].NAMA_CABANG.ToString();
                if (data[i].NAMA_ESELON == null)
                {
                    dr["NAMA_ESELON"] = "";
                }
                else
                    dr["NAMA_ESELON"] = data[i].NAMA_ESELON.ToString();
                
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
