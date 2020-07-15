using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataIjin
    {
        public int jumData { set; get; }
        public List<dataDetailIjin> rows { set; get; }
    }
    class dataDetailIjin
    {
        public string KODE_IJIN { set; get; }
        public string KET_IJIN { set; get; }
        public string PERHITUNGAN { set; get; }
        public string KETENTUAN { set; get; }
        public string JATAH_IJIN { set; get; }
        public string KREDIT { set; get; }
        public string BERLAKU { set; get; }
        public string DASAR { set; get; }
        public string PROSES_DI_AWAL{ set; get; }
        public string KODE_TIDAK_HADIR { set; get; }
        public string HITUNG_HARI_KERJA { set; get; }
        public string HITUNG_JAM_KERJA { set; get; }
        public string POTONGAN_TKK { set; get; }
        public string NAMA_PERHITUNGAN { set; get; }
        public string NAMA_KETENTUAN { set; get; }
        public string NAMA_KREDIT { set; get; }
        public string NAMA_DASAR { set; get; }
        public string NAMA_PROSES_DI_AWAL { set; get; }
        public string NAMA_KODE_TIDAK_HADIR { set; get; }
    }
}
