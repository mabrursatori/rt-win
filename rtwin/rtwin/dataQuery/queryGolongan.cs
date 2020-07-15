﻿using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryGolongan
    {
        public static string getQueryCountGolongan = "SELECT COUNT(KODE_GOLONGAN) FROM taGolongan";
        public static string getQueryComboGolongan = "SELECT KODE_GOLONGAN as name, NAMA_GOLONGAN as content FROM taGolongan";
        public static string getQUeryGolongan(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+",KODE_GOLONGAN, NAMA_GOLONGAN, TARIF_MAKAN, TARIF_LEMBUR, TARIF_UANG_MAKAN_LEMBUR, PAJAK_GOLONGAN FROM taGolongan WHERE KODE_GOLONGAN <> '0'";
        }
        public static string getQueryGolonganDetail(string kodeGolongan)
        {
            return "SELECT KODE_GOLONGAN, NAMA_GOLONGAN, TARIF_MAKAN, TARIF_LEMBUR, TARIF_UANG_MAKAN_LEMBUR, PAJAK_GOLONGAN FROM taGolongan WHERE KODE_GOLONGAN = '"+kodeGolongan+"'";
        }
        public static string getQueryInsertGolongan(string kodeGolongan,string namaGolongan,string tarifMakan,string tarifLembur,string tarifUangMakanLembur,string pajakGolongan)
        {
            return "INSERT INTO taGolongan(KODE_GOLONGAN, NAMA_GOLONGAN, TARIF_MAKAN, TARIF_LEMBUR, TARIF_UANG_MAKAN_LEMBUR, PAJAK_GOLONGAN) VALUES ('" + kodeGolongan + "', '" + namaGolongan + "', '" + tarifMakan + "', '" + tarifLembur + "', '" + tarifUangMakanLembur + "', '" + pajakGolongan + "')";
        }
        public static string getQueryUpdateGolongan(string kodeGolongan, string namaGolongan, string tarifMakan, string tarifLembur, string tarifUangMakanLembur, string pajakGolongan)
        {
            return "UPDATE taGolongan SET NAMA_GOLONGAN = '" + namaGolongan + "', TARIF_MAKAN = '" + tarifMakan + "', TARIF_LEMBUR = '" + tarifLembur + "', TARIF_UANG_MAKAN_LEMBUR = '" + tarifUangMakanLembur + "', PAJAK_GOLONGAN = '" + pajakGolongan + "' WHERE (KODE_GOLONGAN = '" + kodeGolongan + "')";
        }
        public static string getQueryDeleteGolongan(string kodeGolongan)
        {
            return "DELETE FROM taGolongan WHERE (KODE_GOLONGAN = '"+kodeGolongan+"')";
        }
    }
}