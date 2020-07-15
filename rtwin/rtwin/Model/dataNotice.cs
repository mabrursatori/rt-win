using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataNotice
    {
        public int jumData { set; get; }
        public List<dataDetailNotice> rows { set; get; }
    }
    class dataDetailNotice
    {
        public string NIP { set; get; }
        public string NAMA { set; get; }
        public string TGL_SPL { set; get; }
        public string JAM_AWAL_SPL { set; get; }
        public string JAM_AKHIR_SPL { set; get; }
        public string JENIS_KERJA_SPL { set; get; }
        public string STATUS_LEMBUR { set; get; }
        public string PIN { set; get; }
    }
}
