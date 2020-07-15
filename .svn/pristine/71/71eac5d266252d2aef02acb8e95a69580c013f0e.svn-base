using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class querySaldoCuti
    {
        public static string getQueryCountDataSaldoCuti = "SELECT COUNT(NIP) FROM q_SaldoIjin ";
        public static string getQueryKodeIjinCuti = "SELECT [KODE_IJIN] as name, [KET_IJIN] as content FROM [taIjin] WHERE ([KREDIT] = '1')";
        public static string getQueryDataSaldoCuti(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+",NIP, NAMA, TMT, LAMA_KERJA, TGL_AKHIR, KODE_IJIN, KET_IJIN, JATAH_IJIN, TGL_BERLAKU, EXPIRED, DIAMBIL, TIDAK_DIAMBIL, SISA_IJIN, TGL_AWAL, PIN FROM q_SaldoIjin ";
        }
        public static string getProcUpdateJatahIjin(string tahun, string kodeIjin,string SqlFilter)
        {
            return "Exec proc_UpdateJatahIjin '" + tahun + "','" + kodeIjin + "','" + SqlFilter + "'";
        }
        public static string getProc_TambahJatahIjin(string tahun,string kodeIjin,string SqlFilter,string jumlah)
        {
            return "Exec proc_TambahJatahIjin '" + tahun + "','" + kodeIjin + "','" + SqlFilter + "','" + jumlah + "'";
        }
        public static string getProc_PotongJatahIjin(string tahun,string kodeIjin,string sqlFilter,string jmlPotong)
        {
            return "Exec proc_PotongJatahIjin '" + tahun + "','" + kodeIjin + "','" + sqlFilter + "','" + jmlPotong + "'";
        }
        public static string getProc_PotongSisaJatahIjin(string tahun,string kodeIjin, string sqlFilter,string jmlSisa)
        {
            return "Exec proc_PotongSisaJatahIjin '" + tahun + "','" + kodeIjin + "','" + sqlFilter + "','" + jmlSisa + "'";
        }
        public static string getProc_SetExpiredJatahIjin(string tahun, string kodeIjin,string sqlFilter,string tglExpired)
        {
            return "Exec proc_SetExpiredJatahIjin '" + tahun + "','" + kodeIjin + "','" + sqlFilter + "','" + tglExpired + "'";
        }
        public static string getProc_PerpanjangJatahIjin(string tahun, string kodeIjin,string sqlFilter,string lamaBulan)
        {
            return "Exec proc_PerpanjangJatahIjin '" + tahun + "','" + kodeIjin + "','" + sqlFilter + "','" + lamaBulan + "'";
        }
        public static string getProc_HangusJatahIjin(string tahun, string kodeIjin,string sqlFilter)
        {
            return "Exec proc_HangusJatahIjin '" + tahun + "','" + kodeIjin + "','" + sqlFilter + "'";
        }
        public static string filter(string tahun1,string tahun2,string nip,string kodeDeputi,string kodeBiro, string jenisIjin,string username,string gradeID)
        {
            string temp = "";
            if(tahun1!=""&& tahun2 != "")
            { 
                if (temp == "")
                {
                    temp += " WHERE TGL_AKHIR >='1/1/" + tahun1 + "' AND TGL_AKHIR<='12/31/" + tahun2 + "'";
                }
                else
                {
                    temp += " AND TGL_AKHIR >='1/1/" + tahun1 + "' AND TGL_AKHIR<='12/31/" + tahun2 + "'";
                }

            }
            if (nip != "")
            {
                if (temp == "")
                {
                    temp += " WHERE NIP='" + nip + "'";
                }
                else
                {
                    temp += " AND NIP='" + nip + "'";
                }
            }
            if (kodeDeputi != "")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_DEPUTI='" + kodeDeputi + "'";
                }
                else
                {
                    temp += " AND KODE_DEPUTI='" + kodeDeputi + "'";
                }
            }
            else
            {
                if (gradeID == "3")
                {
                    if (temp == "")
                    {
                        temp += " WHERE KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                    }
                    else
                    {
                        temp += " AND KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                    }
                }
            }
            if (kodeBiro != "")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_BIRO='" + kodeBiro + "'";
                }
                else
                {
                    temp += " AND KODE_BIRO='" + kodeBiro + "'";
                }
            }
            if(jenisIjin != "")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_IJIN='" + jenisIjin + "'";
                }
                else
                {
                    temp += " AND KODE_IJIN='" + jenisIjin + "'";
                }
            }
            return temp;

        }
        
    }
}
