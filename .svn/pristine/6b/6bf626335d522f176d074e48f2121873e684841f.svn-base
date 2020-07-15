using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryPaarameterLembur
    {
        public static string getQueryVariabelLembur = "SELECT MIN_LEMBUR,MAKS_LEMBUR,MIN_LEMBUR_LIBUR,MAKS_LEMBUR_LIBUR,MAKS_TOTAL_LEMBUR,BATAS_TERIMA_UANG_MAKAN_LEMBUR,TARIF_UANG_MAKAN_LEMBUR from taVariabel";
        public static string getQueryCountParameterLembur = "SELECT COUNT(KODE_LEMBUR) FROM taParamLembur";
        public static string getQueryParameterLembur()
        {
            return "SELECT KODE_LEMBUR, CASE WHEN KODE_LEMBUR = '1' THEN 'Hari Kerja' ELSE (CASE WHEN KODE_LEMBUR = '2' THEN 'Hari Libur' ELSE 'Hari Libur Nasional' END) END AS HARI_LEMBUR, FAKTOR FROM taParamLembur";
        }
        public static string getQueryDetailParameterLembur(string kodeLembur)
        {
            return "SELECT KODE_LEMBUR, CASE WHEN KODE_LEMBUR = '1' THEN 'Hari Kerja' ELSE (CASE WHEN KODE_LEMBUR = '2' THEN 'Hari Libur' ELSE 'Hari Libur Nasional' END) END AS HARI_LEMBUR, FAKTOR FROM taParamLembur WHERE KODE_LEMBUR='" + kodeLembur + "'";
        }
        public static string getQueryUpdateParameterLembur(string faktor,string kodeLembur)
        {
            return "UPDATE [taParamLembur] SET [FAKTOR] = '" + faktor + "' WHERE [KODE_LEMBUR] = '" + kodeLembur + "'";
        }
        public static string getQueryInsertParameterLembur(string kodeLembur,string faktor)
        {
            return "INSERT INTO taParamLembur(KODE_LEMBUR, JAM_KE, SAMPAI_JAM_KE, FAKTOR) VALUES ('" + kodeLembur + "', 1, 99, '" + faktor + "')";
        }
        public static string getQueryDeleteParameterLembur(string kodeLembur)
        {
            return "DELETE FROM [taParamLembur] WHERE [KODE_LEMBUR] = '" + kodeLembur + "'";
        }
        public static string getQueryUpdateVariabelLembur(string minLembur,string maksLembur,string minLemburLibur,string maksLemburLibur,string maksTotalLembur,string batasTerimaUangMakanLembur,string tarifUangMakanLembur)
        {
            return "update taVariabel set MIN_LEMBUR = '1/1/1900 " + minLembur + ":00',MAKS_LEMBUR = '1/1/1900 " + maksLembur + ":00',MIN_LEMBUR_LIBUR = '1/1/1900 " + minLemburLibur + ":00',MAKS_LEMBUR_LIBUR = '1/1/1900 " + maksLemburLibur + ":00',MAKS_TOTAL_LEMBUR = " + maksTotalLembur + ",BATAS_TERIMA_UANG_MAKAN_LEMBUR = " + batasTerimaUangMakanLembur + ",TARIF_UANG_MAKAN_LEMBUR = " + tarifUangMakanLembur + "";
        }
    }
}
