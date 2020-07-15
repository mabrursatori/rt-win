using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class q_RangeDetail
    {
        public int jumlahData { set; get; }
        public List<dataQ_rangeDetail> rows { set; get; }
    }
    class dataQ_rangeDetail
    {
        public string KODE_RANGE { set; get; }
        public string KODE_DEPARTEMEN { set; get; }
        public string KET_RANGE { set; get; }
        public string NAMA_DEPARTEMEN { set; get; }
    }
}
