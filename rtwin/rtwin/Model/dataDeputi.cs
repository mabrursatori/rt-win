using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataDeputi
    {
        public int jumData { set; get; }
        public List<dataDetailDeputiView> rows { set; get; }
    }
    class dataDetailDeputiView
    {
        public string KODE_DEPUTI { set; get; }
        public string NAMA_DEPUTI { set; get; }
        public string KODE_UNIT { set; get; }
        public string NAMA_UNIT { set; get; }
        public string KODE_INSTANSI { set; get; }
        public string KODE_CABANG { set; get; }
    }
    class dataDetailDeputitabel
    {
        public string KODE_DEPUTI { set; get; }
        public string NAMA_DEPUTI { set; get; }
        public string KODE_UNTI { set; get; }
    }
}
