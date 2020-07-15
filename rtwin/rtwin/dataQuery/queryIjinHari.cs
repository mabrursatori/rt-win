using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryIjinHari
    {
        public static string getQueryCountIjinHari = "SELECT COUNT(NIP) FROM q_IjinHari";
        public static string getDataIjinhari(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+", NIP, NAMA, TGL_AWAL, TGL_AKHIR, KODE_IJIN, KET_IJIN, JML_HARI, TGL_JATAH, BUKTI_IJIN, KET_STATUS, STATUS_IJIN, PERHITUNGAN, LAMA_IJIN, PIN FROM q_IjinHari";
        }
        public static string getDataDetailIjinHari(string nip, string tgl)
        {
            return "SELECT NIP, NAMA, TGL_AWAL, TGL_AKHIR, KODE_IJIN, KET_IJIN, JML_HARI, TGL_JATAH, BUKTI_IJIN, KET_STATUS, STATUS_IJIN, PERHITUNGAN, LAMA_IJIN, PIN FROM q_IjinHari WHERE NIP='" + nip + "' AND TGL_AWAL='" + tgl + "'";
        }
        public static string insertIjinHari(string nip, string tglAwal,string tglAkhir,string kodeIjin,string buktiIjin,bool statusIjin)
        {
            return "INSERT INTO taIjinHari(NIP, TGL_AWAL, TGL_AKHIR, KODE_IJIN, JML_HARI, TGL_JATAH, BUKTI_IJIN, STATUS_IJIN) VALUES ('" + nip + "','" + tglAwal + "','" + tglAkhir + "','" + kodeIjin + "', dbo.SetJmlHari('" + nip + "','" + kodeIjin + "' ,'" + tglAwal + "','" + tglAkhir + "' ), dbo.SetTglJatah('" + nip + "','" + kodeIjin + "','" + tglAwal + "','" + tglAkhir + "'), '" + buktiIjin + "','" + statusIjin + "')";
        }
        public static string updateIjinHari(string tglAkhir,string kodeIjin,string buktiIjin,bool statusIjin,string nip,string tglAwal){
            return "UPDATE taIjinHari SET TGL_AKHIR = '" + tglAkhir + "', KODE_IJIN = '" + kodeIjin + "', BUKTI_IJIN = '" + buktiIjin + "', STATUS_IJIN = '" + statusIjin + "' WHERE (NIP = '" + nip + "') AND (TGL_AWAL = '" + tglAwal + "')";
        }
        public static string deleteIjinHari(string nip,string tgalAwal)
        {
            return "DELETE FROM taIjinHari WHERE (NIP = '" + nip + "') AND (TGL_AWAL = '" + tgalAwal + "')";
        }
        public static string filter(string tglAwal, string tglAkhir, string nip, string kodeDeputi, string kodeBiro,string statusIjin,string username,string gradeID)
        {
            string temp = "";
            if (tglAwal != "" && tglAkhir != "")
            {
                if (temp == "")
                {
                    temp += " WHERE TGL_AWAL>='" + tglAwal + "' AND TGL_AWAL<='" + tglAkhir + "'";
                }
                else
                {
                    temp += " AND TGL_MASUK>='" + tglAwal + "' AND TGL_MASUK<='" + tglAkhir + "'";
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
            if (statusIjin != "")
            {
                if (temp == "")
                {
                    temp += " WHERE STATUS_IJIN='" + statusIjin + "'";
                }
                else
                {
                    temp += " AND STATUS_IJIN='" + statusIjin + "'";
                }
            }
            return temp;

        }
    }
}
