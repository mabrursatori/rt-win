using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class strukturDataPola
    {
        public int jumlahData { set; get; }
        public List<dataPolaMingguan> rows { set; get; }
    }
    class dataPolaMingguan
    {
        public string KODE_SHIFT { set; get; }
        public string NAMA_GROUP { set; get; }
        public string LIBUR_NASIONAL { set; get; }
        public string KET_LIBUR { set; get; }
        public string NAMA_CABANG { set; get; }
        public string Minggu { set; get; }
        public string Senin { set; get; }
        public string Selasa { set; get; }
        public string Rabu { set; get; }
        public string Kamis { set; get; }
        public string Jumat { set; get; }
        public string Sabtu { set; get; }
        public string KODE_DEPARTEMEN { set; get; }
    }
}
