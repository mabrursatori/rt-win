using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataGrade
    {
        public int jumData { set; get; }
        public List<dataDetailGrade> rows { set; get; }
    }
    class dataDetailGrade
    {
        public string KODE_GRADE { set; get; }
        public string NILAI_GRADE { set; get; }
    }
}
