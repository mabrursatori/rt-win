using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryIjinPerJam
    {
        public static string getQueryComboJenisIjinPerJam = "SELECT KODE_IJIN AS name, '[' + KODE_IJIN + '] ' + KET_IJIN AS content FROM taIjin WHERE (KODE_TIDAK_HADIR >= '2') AND (KODE_TIDAK_HADIR <= '5') ORDER BY KODE_IJIN";
        public static string getQueryCountDataIjinPerJam = "SELECT COUNT (NIP) FROM q_IjinJam";
        public static string getQueryDataIjinPerJam(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+",NIP, NAMA, TGL_IJIN, JAM_AWAL_IJIN, JAM_AKHIR_IJIN, KODE_IJIN, KET_IJIN, ALASAN_IJIN, IJIN_DINAS, STATUS_IJIN, CASE WHEN IJIN_DINAS = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_IJIN_DINAS, PIN FROM q_IjinJam";
        }
        public static string getQueryDataDetailIjinperJam(string nip,string tglIjin)
        {
            return "SELECT NIP, NAMA, TGL_IJIN, JAM_AWAL_IJIN, JAM_AKHIR_IJIN, KODE_IJIN, KET_IJIN, ALASAN_IJIN, IJIN_DINAS, STATUS_IJIN, CASE WHEN IJIN_DINAS = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_IJIN_DINAS, PIN FROM q_IjinJam Where NIP='" + nip + "' AND TGL_IJIN='" + tglIjin + "'";
        }
        public static string getQueryInsertDataIjinPerjam(string nip,string tglIjin,string jamAwalIjin,string jamAkhirIjin,string kodeIjin,string alasanIjin,string ijinDinas,string statusIjin)
        {
            if (jamAwalIjin == "")
            {
                jamAwalIjin = "NULL";
            }
            else
            {
                jamAwalIjin = "'" + jamAwalIjin + "'";
            }
            if (jamAkhirIjin == "")
            {
                jamAkhirIjin = "NULL";
            }
            else
            {
                jamAkhirIjin = "'" + jamAkhirIjin + "'";
            }
            return "INSERT INTO taIjinJam(NIP, TGL_IJIN, JAM_AWAL_IJIN, JAM_AKHIR_IJIN, KODE_IJIN, ALASAN_IJIN, IJIN_DINAS, STATUS_IJIN) VALUES ('" + nip + "','" + tglIjin + "'," + jamAwalIjin + "," + jamAkhirIjin + ", '" + kodeIjin + "', '" + alasanIjin + "','" + ijinDinas + "', '" + statusIjin + "')";
        }
        public static string getQueryUpdateDataIjinPerJam(string jamAwal,string jamAkhir,string kodeIjin,string alasanIjin,string ijinDinas,string statusIjin, string nip,string tglIjin)
        {
            if (jamAwal == "")
            {
                jamAwal = "NULL";
            }
            else
            {
                jamAwal = "'" + jamAwal + "'";
            }
            if (jamAkhir == "")
            {
                jamAwal = "NULL";
            }
            else
            {
                jamAkhir = "'" + jamAkhir + "'";
            }
            return "UPDATE taIjinJam SET JAM_AWAL_IJIN = " + jamAwal + ", JAM_AKHIR_IJIN = " + jamAkhir + ", KODE_IJIN = '" + kodeIjin + "', ALASAN_IJIN = '" + alasanIjin + "', IJIN_DINAS = '" + ijinDinas + "', STATUS_IJIN = '" + statusIjin + "' WHERE (NIP = '" + nip + "') AND (TGL_IJIN = '" + tglIjin + "')";
        }
        public static string getQueryDeleteDataIjinPerJam(string nip,string tglIjin)
        {
            return "DELETE FROM taIjinJam WHERE (NIP = '" + nip + "') AND (TGL_IJIN = '" + tglIjin + "')";
        }
        public static string filter(string tglAwal, string tglAkhir, string nip, string kodeDeputi, string kodeBiro, string statusIjin,string username,string gradeID)
        {
            string temp = "";
            if (tglAwal != "" && tglAkhir != "")
            {
                if (temp == "")
                {
                    temp += " WHERE TGL_IJIN>='" + tglAwal + "' AND TGL_IJIN<='" + tglAkhir + "'";
                }
                else
                {
                    temp += " AND TGL_IJIN>='" + tglAwal + "' AND TGL_IJIN<='" + tglAkhir + "'";
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
