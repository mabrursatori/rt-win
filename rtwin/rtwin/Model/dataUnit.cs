using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataUnit
    {
        public int jumData { set; get; }
        public List<dataDetailUnitView> rows { set; get; }
    }
    class dataDetailUnitView
    {
        public string KODE_UNIT { set; get; }
        public string NAMA_UNIT { set; get; }
        public string KODE_INSTANSI { set; get; }
        public string NAMA_INSTANSI { set; get; }
        public string KODE_CABANG { set; get; }
        public string NAMA_CABANG { set; get; }
    }
    class dataDetailUnitTabel
    {
        public string KODE_UNIT { set; get; }
        public string NAMA_UNIT { set; get; }
        public string KODE_INSTANSI { set; get; }
        public string KODE_CABANG { set; get; }
    }
}
