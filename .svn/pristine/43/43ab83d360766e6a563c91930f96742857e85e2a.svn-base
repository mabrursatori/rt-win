using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryGrid
    {
        public static string getQueryCOuntGrade = "SELECT COUNT(KODE_GRADE) FROM taGrade WHERE KODE_GRADE > 0 ";
        public static string getQueryComboGrade = "SELECT KODE_GRADE as name, NILAI_GRADE as content FROM taGrade";
        public static string getQueryGrade(string orderBy,string ascdesc)
        {
            return "SELECT " + AriLib.rowNumberQuery(orderBy, ascdesc) + ",KODE_GRADE, NILAI_GRADE FROM taGrade WHERE KODE_GRADE > 0 ";
        }
        public static string getQueryGradeDetail(string kodeGrade)
        {
            return "SELECT KODE_GRADE, NILAI_GRADE FROM taGrade WHERE KODE_GRADE > 0 AND KODE_GRADE='" + kodeGrade + "'";
        }
        public static string getQueryInsertGrade(string kodeGrade,string nilaiGrade)
        {
            return "INSERT INTO taGrade(KODE_GRADE, NILAI_GRADE) VALUES ('" + kodeGrade + "','" + nilaiGrade + "')";
        }
        public static string getQueryUpdateGrade(string kodeGrade, string nilaiGrade)
        {
            return "UPDATE taGrade SET NILAI_GRADE = '"+nilaiGrade+"' WHERE (KODE_GRADE = '"+kodeGrade+"')";
        }
        public static string getQueryDeleteGrade(string kodeGrade)
        {
            return "DELETE FROM taGrade WHERE (KODE_GRADE = '"+kodeGrade+"')";
        }
    }
}
