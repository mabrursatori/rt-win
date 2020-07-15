using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    public class dataLaporanTahunan
    {
        public string BULAN { set; get; }
        public string HARI_KERJA { set; get; }
        public string HARI_HADIR { set; get; }
        public string HARI_TDK_HADIR { set; get; }
        public string HARI_TELAT { set; get; }
        public string HARI_CPT_PLNG { set; get; }
        public string HARI_HDR_LBR { set; get; }
        public string HARI_ABSEN_1X { set; get; }
        public string IJIN_DINAS_LUAR { set; get; }
        public string IJIN_DINAS_PD { set; get; }
        public string IJIN_PRIBADI_CAP { set; get; }
        public string IJIN_PRIBADI_CT { set; get; }
        public string IJIN_PRIBADI_S { set; get; }
        public string IJIN_PRIBADI_SDR { set; get; }
        public string IJIN_PER_JAM { set; get; }
        public string LEMBUR { set; get; }
    }
}
