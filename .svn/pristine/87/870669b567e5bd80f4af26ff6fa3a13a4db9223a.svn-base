using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryPolaKolektif
    {
        public static string comboPola = "SELECT right(KODE_SHIFT, len(KODE_SHIFT)-1) AS Kode_Group, '[' + right(KODE_SHIFT, len(KODE_SHIFT)-1) + ']' + ' : ' + NAMA_GROUP as judul FROM taPola WHERE (SUBSTRING(KODE_SHIFT, 1, 1)";
        public static string getDataPolaFormatShiftFormat(string kodeShift,string tanggal)
        {
            return "SELECT dbo.PolaFormat('" + kodeShift + "','" + tanggal + "') as Format1,dbo.ShiftKFormat('" + kodeShift + "','" + tanggal + "') as Format2";
        }
    }
}
