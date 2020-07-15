using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryLibur
    {
        public static string getQueryCountDataGridLibur(string year)
        {
            return "SELECT COUNT(TGL_LIBUR)from taLibur WHERE YEAR(TGL_LIBUR)='" + year + "'";
        }
        public static string getQueryDataGridLibur(string orderBy, string ascdesc,string year)
        {
            return "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID,TGL_LIBUR, KET_LIBUR FROM taLibur WHERE YEAR(TGL_LIBUR)= '" + year + "'";
        }
        public static string getQueryDetailDataLibur(string tgl)
        {
            return "SELECT * FROM taLibur WHERE TGL_LIBUR='" + tgl + "'";
        }
        public static string getQueryInputLibur(string tglLibur,string ketLibur)
        {
            return "INSERT INTO taLibur(TGL_LIBUR, KET_LIBUR) VALUES ('" + tglLibur + "', '" + ketLibur + "')";
        }
        public static string getQueryUpdateLibur(string tglLiburNew,string tglLiburOld,string ketLibur)
        {
            return "UPDATE taLibur SET TGL_LIBUR = '" + tglLiburNew + "', KET_LIBUR ='" + ketLibur + "' WHERE (TGL_LIBUR = '" + tglLiburOld + "')";
        }
        public static string getQueryHapusLibur(string tglLibur)
        {
            return "DELETE FROM taLibur WHERE (TGL_LIBUR = '" + tglLibur + "')";
        }
    }
}
