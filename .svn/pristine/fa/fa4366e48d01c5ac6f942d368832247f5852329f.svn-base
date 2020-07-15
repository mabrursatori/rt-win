using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryJenisLaporan
    {
        public static string getQueryComboJenisLaporan(string kodeGrade)
        {
            string where = "";
            if (kodeGrade == "1")
            {
                where = "LAP_ADMIN = 1";
            } else if (kodeGrade == "3")
            {
                where = "LAP_OPERATOR = 1";
            } else 
                where = "LAP_USER = 1";

            return "select KODE_LAPORAN as name, NAMA_LAPORAN as content from taLaporan where " + where;
        }
    }
}
