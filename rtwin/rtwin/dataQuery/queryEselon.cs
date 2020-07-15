using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryEselon
    {
        public static string getQueryCOuntEselon = "SELECT COUNT(KODE_ESELON) FROM taEselon";
        public static string getQueryComboEselon = "SELECT KODE_ESELON as name, NAMA_ESELON as content FROM taEselon";
        public static string getQueryEselon(string orderBy, string ascdesc)
        {
            return "SELECT " + AriLib.rowNumberQuery(orderBy, ascdesc) + ",KODE_ESELON, NAMA_ESELON FROM taEselon WHERE KODE_ESELON <> '--' ";
        }
        public static string getQueryEselonDetail(string kodeEselon)
        {
            return "SELECT KODE_ESELON, NAMA_ESELON FROM taEselon WHERE KODE_ESELON ='" + kodeEselon + "' ";
        }
        public static string getqueryInsertEselon(string kodeEselon,string namaEselon)
        {
            return "INSERT INTO taEselon(KODE_ESELON, NAMA_ESELON) VALUES ('" + kodeEselon + "', '" + namaEselon + "')";
        }
        public static string getQueryUpdateEselon(string kodeEselon, string namaEselon)
        {
            return "UPDATE taEselon SET NAMA_ESELON = '" + namaEselon + "' WHERE (KODE_ESELON = '" + kodeEselon + "')";
        }
        public static string getDeleteEselon(string kodeEselon)
        {
            return "DELETE FROM taEselon WHERE KODE_ESELON='" + kodeEselon + "'";
        }
    }
    
}
