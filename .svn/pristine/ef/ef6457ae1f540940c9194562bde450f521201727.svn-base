using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryCabang
    {
        public static string getQueryCabang ="SELECT KODE_CABANG, NAMA_CABANG, LEMBUR_OTOMATIS, LEMBUR_LIBUR, CASE WHEN PERHITUNGAN_LEMBUR=1 THEN 'Lembur AWAL' ELSE(CASE WHEN PERHITUNGAN_LEMBUR= 2 THEN 'Lembur Akhir' ELSE (CASE WHEN PERHITUNGAN_LEMBUR = 3 THEN 'Lembur Awal & Akhir' END)END)  END AS PERHITUNGAN_LEMBUR2,PERHITUNGAN_LEMBUR FROM taCabang WHERE KODE_CABANG<> '---' AND KODE_CABANG<>'--'";

        public static string getQueryDetailCabang(string kodeCabang)
        {
            return "SELECT KODE_CABANG, NAMA_CABANG, LEMBUR_OTOMATIS, LEMBUR_LIBUR, CASE WHEN PERHITUNGAN_LEMBUR = 1 THEN 'Lembur AWAL' ELSE(CASE WHEN PERHITUNGAN_LEMBUR = 2 THEN 'Lembur Akhir' ELSE(CASE WHEN PERHITUNGAN_LEMBUR = 3 THEN 'Lembur Awal & Akhir' END)END)  END AS PERHITUNGAN_LEMBUR2,PERHITUNGAN_LEMBUR FROM taCabang WHERE KODE_CABANG <> '---' AND KODE_CABANG<>'--' AND KODE_CABANG='" + kodeCabang + "'";
        }

        public static string getQueryUpdateCabang(string lemburOtomatis,string lemburLibur,string perhitunganLembur,string kodeCabang)
        {
            return "UPDATE taCabang SET LEMBUR_OTOMATIS = '" + lemburOtomatis + "', LEMBUR_LIBUR = '" + lemburLibur + "', PERHITUNGAN_LEMBUR = '" + perhitunganLembur + "' WHERE (KODE_CABANG = '" + kodeCabang + "')";
        }
    }
}
