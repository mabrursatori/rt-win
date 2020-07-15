using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryUnit
    {
        public static string queryDataGridUnit(string orderBy,string ascdesc)
        {
            return "select ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID, KODE_UNIT,NAMA_UNIT,KODE_INSTANSI,NAMA_INSTANSI,KODE_CABANG,NAMA_CABANG from q_Unit";
        }
        public static string getQueryDataUnit = "select KODE_UNIT,NAMA_UNIT,KODE_INSTANSI,KODE_CABANG from taUnit";
        public static string getQueryComboBoxUnit = "select KODE_UNIT AS name,NAMA_UNIT AS content from taUnit";

    }
}
