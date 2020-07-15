using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryDeputi
    {
        public static string getQueryComboDeputi = "SELECT KODE_DEPUTI as name, NAMA_DEPUTI as content FROM taDeputi";
        public static string getQueryCountDeputi = "SELECT COUNT(KODE_DEPUTI) FROM q_Deputi";
        public static string getQueryDataGridDeputi(string orderBy, string ascdesc)
        {
            return "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID,KODE_DEPUTI, NAMA_DEPUTI, KODE_UNIT, NAMA_UNIT, KODE_INSTANSI FROM q_Deputi";
        }
        public static string getQueryDetailDeputi(string kodeDeputi)
        {
            return "SELECT KODE_DEPUTI, NAMA_DEPUTI, KODE_UNIT, NAMA_UNIT, KODE_INSTANSI FROM q_Deputi WHERE KODE_DEPUTI='" + kodeDeputi + "'";
        }
        public static string getQueryInsertDeputi(string kodeDeputi,string namaDeputi,string kodeUnit)
        {
            return "INSERT INTO taDeputi(KODE_DEPUTI, NAMA_DEPUTI, KODE_UNIT) VALUES ('" + kodeDeputi + "', '" + namaDeputi + "', '" + kodeUnit + "')";
        }
        public static string getQueryDeleteDeputi(string kodeDeputi)
        {
            return "DELETE FROM taDeputi WHERE (KODE_DEPUTI = '" + kodeDeputi + "')";
        }
        public static string getQueryUpdateDeputi(string kodeDeputi,string namaDeputi,string kodeUnit)
        {
            return "UPDATE taDeputi SET NAMA_DEPUTI = '"+namaDeputi+"', KODE_UNIT = '"+kodeUnit+"' WHERE (KODE_DEPUTI = '"+kodeDeputi+"')";
        }
        public static string getQueryGRantDepartemenDeputi(string kodeLevel,string username)
        {
            string filter = "";
            if (kodeLevel == "3")
            {
                filter = " WHERE KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username='" + username + "') OR KODE_DEPUTI='000'";
            }
            return filter;
        }

    }
}
