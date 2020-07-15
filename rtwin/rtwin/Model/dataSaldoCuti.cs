using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataSaldoCuti
    {
        public int jumData { set; get; }
        public List<dataDetailSaldoCuti> rows { set; get; }
    }
    class dataDetailSaldoCuti
    {
        public string NIP { set; get; }
        public string NAMA { set; get; }
        public string TMT { set; get; }
        public string LAMA_KERJA { set; get; }
        public string TGL_AKHIR { set; get; }
        public string KODE_IJIN { set; get; }
        public string KET_IJIN { set; get; }
        public string JATAH_IJIN { set; get; }
        public string TGL_BERLAKU { set; get; }
        public string EXPIRED { set; get; }
        public string DIAMBIL { set; get; }
        public string TIDAK_DIAMBIL { set; get; }
        public string SISA_IJIN { set; get; }
        public string TGL_AWAL { set; get; }
        public string PIN { set; get; }
    }
}
