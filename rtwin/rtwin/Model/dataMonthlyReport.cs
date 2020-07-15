﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    public class dataMonthlyReport
    {
        public string NIP { set; get; }
        public string NAMA { set; get; }
        public string TGL_MASUK { set; get; }
        public string JAM_AWAL { set; get; }
        public string JAM_AKHIR { set; get; }
        public string JAM_MASUK { set; get; }
        public string JAM_KELUAR { set; get; }
        public string TERLAMBAT { set; get; }
        public string CEPAT_PULANG { set; get; }
        public string KET_SINGKAT { set; get; }
        public string UANG_MAKAN { set; get; }
        public string PERSEN_POTONGAN { set; get; }
        public string KET_POTONGAN { set; get; }
        public string NAMA_DEPARTEMEN { set; get; }
        public string NAMA_JABATAN { set; get; }
    }

    class filterBulan
    {
        public string angkaBulan { set; get; }
        public string namaBulan { set; get; }
        public string jumlahHari { set; get; }
    }

}