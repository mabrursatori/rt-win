using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataFaktorPengali
    {
        public int jumData { set; get; }
        public List<dataDetailFaktorPengali> rows { set; get; }
    }
    class dataDetailFaktorPengali
    {
        public string KODE_LEMBUR { set; get; }
        public string HARI_LEMBUR { set; get; }
        public string FAKTOR { set; get; }
    }
}
