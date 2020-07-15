﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryMonthlyReporting
    {
        public static string queryMonthly()
        {
            return "select NIP, NAMA, TGL_MASUK,JAM_AWAL,JAM_AKHIR,JAM_MASUK,JAM_KELUAR,TERLAMBAT,CEPAT_PULANG,KETERANGAN,TIPE_POTONGAN,UANG_MAKAN,PERSEN_POTONGAN from q_AbsenHarianDetil where NIP='2000000050' AND TGL_MASUK >= '2020-04-01' AND TGL_MASUK<= '2020-04-30' ";
        }
        public static string queryMonthlyParams(string param)
        {
            return "select NIP, NAMA, TGL_MASUK,JAM_AWAL,JAM_AKHIR,JAM_MASUK,JAM_KELUAR,TERLAMBAT,CEPAT_PULANG,KET_SINGKAT,KET_POTONGAN,UANG_MAKAN,PERSEN_POTONGAN, NAMA_DEPARTEMEN, NAMA_JABATAN from q_AbsenHarianDetil where NIP IS NOT NULL " + param;
        }
    }
}
