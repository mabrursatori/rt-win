using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryIjin
    {
        public static string getDataIjinComboBox = "SELECT KODE_IJIN as name, '[' + KODE_IJIN + '] ' + KET_IJIN AS content FROM taIjin WHERE (KODE_TIDAK_HADIR = '1') ORDER BY KODE_IJIN";
        public static string getQueryCountDataIjin = "SELECT COUNT(KODE_IJIN) FROM taIjin";
        public static string getQueryDetailDataIjin(string kodeIjin)
        {
            return "SELECT KODE_IJIN, KET_IJIN, PERHITUNGAN, KETENTUAN, JATAH_IJIN, KREDIT, BERLAKU, DASAR, PROSES_DI_AWAL, KODE_TIDAK_HADIR, HITUNG_HARI_KERJA, HITUNG_JAM_KERJA, POTONGAN_TKK, CASE WHEN PERHITUNGAN = '1' THEN 'Hari Kalender' ELSE (CASE WHEN PERHITUNGAN = '2' THEN 'Hari kerja' ELSE 'Paruh Hari' END) END AS NAMA_PERHITUNGAN, CASE WHEN KETENTUAN = '0' THEN '-' ELSE (CASE WHEN KETENTUAN = '1' THEN 'Setiap Tahun' ELSE (CASE WHEN KETENTUAN = '2' THEN 'Setelah 6 tahun' ELSE (CASE WHEN KETENTUAN = '3' THEN 'Setelah 7 tahun' ELSE (CASE WHEN KETENTUAN = '4' THEN '1 X Seumur hidup' ELSE 'Kebijaksanaan' END) END) END) END) END AS NAMA_KETENTUAN, CASE WHEN Kredit = '0' THEN 'Manual' ELSE 'Otomatis' END AS NAMA_KREDIT, CASE WHEN Dasar = '0' THEN 'Tgl Masuk Kerja' ELSE 'Awal Tahun' END AS NAMA_DASAR, CASE WHEN PROSES_DI_AWAL = '1' THEN 'Ya' ELSE 'Tidak' END AS NAMA_PROSES_DI_AWAL, CASE WHEN KODE_TIDAK_HADIR = '0' THEN 'Tanpa Keterangan' ELSE (CASE WHEN KODE_TIDAK_HADIR = '1' THEN 'Ijin/Cuti/Dinas/Sakit' ELSE (CASE WHEN KODE_TIDAK_HADIR = '2' THEN 'Terlambat' ELSE (CASE WHEN KODE_TIDAK_HADIR = '3' THEN 'Cepat Pulang' ELSE (CASE WHEN KODE_TIDAK_HADIR = '4' THEN 'Lambat & Cepat Pulang' ELSE (CASE WHEN KODE_TIDAK_HADIR = '5' THEN 'Paruh Hari' ELSE 'Alpha/Mangkir' END) END) END) END) END) END AS NAMA_KODE_TIDAK_HADIR FROM taIjin where KODE_IJIN='" + kodeIjin + "'";
        }
        public static string getQueryDataIjin(string orderBy, string ascdesc)
        {
            return "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID, KODE_IJIN, KET_IJIN, PERHITUNGAN, KETENTUAN, JATAH_IJIN, KREDIT, BERLAKU, DASAR, PROSES_DI_AWAL, KODE_TIDAK_HADIR, HITUNG_HARI_KERJA, HITUNG_JAM_KERJA, POTONGAN_TKK, CASE WHEN PERHITUNGAN = '1' THEN 'Hari Kalender' ELSE (CASE WHEN PERHITUNGAN = '2' THEN 'Hari kerja' ELSE 'Paruh Hari' END) END AS NAMA_PERHITUNGAN, CASE WHEN KETENTUAN = '0' THEN '-' ELSE (CASE WHEN KETENTUAN = '1' THEN 'Setiap Tahun' ELSE (CASE WHEN KETENTUAN = '2' THEN 'Setelah 6 tahun' ELSE (CASE WHEN KETENTUAN = '3' THEN 'Setelah 7 tahun' ELSE (CASE WHEN KETENTUAN = '4' THEN '1 X Seumur hidup' ELSE 'Kebijaksanaan' END) END) END) END) END AS NAMA_KETENTUAN, CASE WHEN Kredit = '0' THEN 'Manual' ELSE 'Otomatis' END AS NAMA_KREDIT, CASE WHEN Dasar = '0' THEN 'Tgl Masuk Kerja' ELSE 'Awal Tahun' END AS NAMA_DASAR, CASE WHEN PROSES_DI_AWAL = '1' THEN 'Ya' ELSE 'Tidak' END AS NAMA_PROSES_DI_AWAL, CASE WHEN KODE_TIDAK_HADIR = '0' THEN 'Tanpa Keterangan' ELSE (CASE WHEN KODE_TIDAK_HADIR = '1' THEN 'Ijin/Cuti/Dinas/Sakit' ELSE (CASE WHEN KODE_TIDAK_HADIR = '2' THEN 'Terlambat' ELSE (CASE WHEN KODE_TIDAK_HADIR = '3' THEN 'Cepat Pulang' ELSE (CASE WHEN KODE_TIDAK_HADIR = '4' THEN 'Lambat & Cepat Pulang' ELSE (CASE WHEN KODE_TIDAK_HADIR = '5' THEN 'Paruh Hari' ELSE 'Alpha/Mangkir' END) END) END) END) END) END AS NAMA_KODE_TIDAK_HADIR FROM taIjin";
        }
        public static string getQueryUpdateDataIjin(string ketIjin, string perhitungan, string ketentuan, string jatahIjin, string kredit, string berlaku, string dasar, string posesDiAwal, string kodeTidakHadir, string HitungHariKerja, string hitungJamKerja, string potonganTKK, string kodeIjin)
        {
            return "UPDATE taIjin SET KET_IJIN = '" + ketIjin + "', PERHITUNGAN = '" + perhitungan + "', KETENTUAN = '" + ketentuan + "', JATAH_IJIN ='" + jatahIjin + "', KREDIT = '" + kredit + "', BERLAKU = '" + berlaku + "', DASAR = '" + dasar + "', PROSES_DI_AWAL = '" + posesDiAwal + "', KODE_TIDAK_HADIR = '" + kodeTidakHadir + "', HITUNG_HARI_KERJA ='" + HitungHariKerja + "', HITUNG_JAM_KERJA = '" + hitungJamKerja + "', POTONGAN_TKK = '" + potonganTKK + "' WHERE(KODE_IJIN = '" + kodeIjin + "')";
        }
        public static string getQueryInsertDataIjin(string ketIjin,string perhitungan,string ketentuan,string jatahIjin,string kredit,string berlaku,string dasar,string posesDiAwal,string kodeTidakHadir,string HitungHariKerja,string hitungJamKerja,string potonganTKK,string kodeIjin)
        {
            return "INSERT INTO taIjin(KODE_IJIN, KET_IJIN, PERHITUNGAN, KETENTUAN, JATAH_IJIN, KREDIT, BERLAKU, DASAR, PROSES_DI_AWAL, KODE_TIDAK_HADIR, HITUNG_HARI_KERJA, HITUNG_JAM_KERJA, POTONGAN_TKK) VALUES ('" + kodeIjin + "', '" + ketIjin + "','" + perhitungan + "','" + ketentuan + "','" + jatahIjin + "','" + kredit + "','" + berlaku + "','" + dasar + "','" + posesDiAwal + "','" + kodeTidakHadir + "','" + HitungHariKerja + "','" + hitungJamKerja + "' ,'" + potonganTKK + "')";
        }
        public static string getQueryDeleteDataIjin(string kodeIjin)
        {
            return "DELETE FROM taIjin WHERE (KODE_IJIN = '" + kodeIjin + "')";
        }
            
    }
}
