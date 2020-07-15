using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryNotice
    {
        public static string queryGetDataCountNotic = "SELECT COUNT(NIP) FROM q_Lembur";
        public static string queryGetDataNotice(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+" ,NIP, NAMA, TGL_SPL, JAM_AWAL_SPL, JAM_AKHIR_SPL, JENIS_KERJA_SPL, STATUS_LEMBUR, PIN FROM q_Lembur";
        }
        public static string queryGetDataDetailNotice(string nip,string tglLembur)
        {
            return "SELECT NIP, NAMA, TGL_SPL, JAM_AWAL_SPL, JAM_AKHIR_SPL, JENIS_KERJA_SPL, STATUS_LEMBUR, PIN FROM q_Lembur WHERE NIP='" + nip + "' AND TGL_SPL='" + tglLembur + "'"; 
        }
        public static string queryInsertNotice(string nip,string tglSpl,string jamAwalSpl,string jamAkhirSpl,string jenisKerjaSpl,string statusLembur)
        {
            return "INSERT INTO taLembur(NIP, TGL_SPL, JAM_AWAL_SPL, JAM_AKHIR_SPL, JENIS_KERJA_SPL, STATUS_LEMBUR) VALUES ('" + nip + "', '" + tglSpl + "','" + jamAwalSpl + "','" + jamAkhirSpl + "' ,'" + jenisKerjaSpl + "','" + statusLembur + "')";
        }
        public static string queryUpdateNotice(string nip, string tglSpl, string jamAwalSpl, string jamAkhirSpl, string jenisKerjaSpl, string statusLembur)
        {
            return "UPDATE taLembur SET JAM_AWAL_SPL ='" + jamAwalSpl + "', JAM_AKHIR_SPL = '" + jamAkhirSpl + "', JENIS_KERJA_SPL = '" + jenisKerjaSpl + "', STATUS_LEMBUR = '" + statusLembur + "' WHERE (NIP = '" + nip + "') AND (TGL_SPL = '" + tglSpl + "')";
        }
        public static string queryDeleteNotice(string nip,string tglSpl)
        {
            return "DELETE FROM taLembur WHERE (NIP = '" + nip + "') AND (TGL_SPL = '" + tglSpl + "')";
        }
        public static string filterNotice(string tglAwal,string tglAkhir,string nip,string kodeDeputi,string kodeBiro,string statusLembur, string username, string gradeID)
        {
            string temp = "";
            if(tglAwal!="" && tglAkhir != "")
            {
                if (temp == "")
                {
                    temp += " Where TGL_SPL>='" + tglAwal + "' AND TGL_SPL<='" + tglAkhir + "'";
                }
                else
                {
                    temp += " AND TGL_SPL>='" + tglAwal + "' AND TGL_SPL<='" + tglAkhir + "'";
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
           
            return temp;
        }
    }
}
