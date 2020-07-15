using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryBiro
    {
        public static string queryCountBiro = "SELECT COUNT(KODE_BIRO) FROM q_Biro";
        public static string queryComboBiro = "SELECT KODE_BIRO as name, NAMA_BIRO as content FROM taBiro";
        public static string queryComboBiroFilter(string kodeDeputi)
        {
           return queryComboBiro + " WHERE KODE_DEPUTI='" + kodeDeputi + "' or KODE_BIRO='0000'";
        }
        public static string getQueryBiroView(string orderBy, string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+",KODE_BIRO, NAMA_BIRO, KODE_DEPUTI, NAMA_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Biro ";
        }
        public static string getQueryDetilBiro(string kodeBiro)
        {
            return "SELECT KODE_BIRO, NAMA_BIRO, KODE_DEPUTI, NAMA_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Biro WHERE KODE_BIRO='"+kodeBiro+"' ORDER BY KODE_BIRO";
        }
        public static string getQueryInsertBiro(string kodeBiro,string namaBiro,string kodeDeputi)
        {
            return "INSERT INTO taBiro(KODE_BIRO, NAMA_BIRO, KODE_DEPUTI) VALUES ('" + kodeBiro + "','" + namaBiro + "', '" + kodeDeputi + "')";
        }
        public static string getQueryUpdateBiro(string kodeBiro,string namaBiro,string kodeDeputi)
        {
            return "UPDATE taBiro SET NAMA_BIRO = '" + namaBiro + "', KODE_DEPUTI = '" + kodeDeputi + "' WHERE (KODE_BIRO = '" + kodeBiro + "')";
        }
        public static string getQueryDeleteBiro(string kodeBiro)
        {
            return "DELETE FROM taBiro WHERE(KODE_BIRO = '" + kodeBiro + "')";
        }
        public static string filter(string kodeDeputi)
        {
            string temp = "";
            if (kodeDeputi != "")
            {
                temp = " WHERE KODE_DEPUTI='" + kodeDeputi + "'";
            }
            return temp;
        }
    }
}
