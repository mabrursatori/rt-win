using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataLibur
    {
        public int jumData { set; get; }
        public List<detailDataLibur> rows { set; get; }
    }
    class detailDataLibur
    {
        public string TGL_LIBUR { set; get; }
        public string KET_LIBUR { set; get; }
    }
}
