using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class DataIjinPerJam
    {
        public int jumData { set; get; }
        public List<DataDetailIjinPerJam> rows { set; get; }
    }
    class DataDetailIjinPerJam
    {
        public string NIP { set; get; }
        public string NAMA { set; get; }
        public string TGL_IJIN { set; get; }
        public string JAM_AWAL_IJIN { set; get; }
        public string JAM_AKHIR_IJIN { set; get; }
        public string KODE_IJIN { set; get; }
        public string KET_IJIN { set; get; }
        public string ALASAN_IJIN { set; get; }
        public string IJIN_DINAS { set; get; }
        public string STATUS_IJIN { set;get; }
        public string KET_IJIN_DINAS { set; get; }
        public string PIN { set; get; }
    }
}
