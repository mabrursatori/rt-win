﻿using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace rtwin.dataQuery
{
    class queryJabatan
    {
        public static string getQueryCOuntJabatan = "SELECT COUNT(KODE_JABATAN) FROM taJabatan where KODE_JABATAN <>'00'";
        public static string getQueryComboJabatan = "SELECT KODE_JABATAN as name, NAMA_JABATAN as content FROM taJabatan";
        public static string getQUeryJabatan(string orderBy, string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+", KODE_JABATAN, NAMA_JABATAN FROM taJabatan WHERE KODE_JABATAN <> '00'";
        }
        public static string getQueryDEtailJabatan(string kodeJabatan)
        {
            return "SELECT  KODE_JABATAN, NAMA_JABATAN FROM taJabatan WHERE KODE_JABATAN <> '00' AND KODE_JABATAN='"+kodeJabatan+"'";
        }
        public static string getqueryInsertJabatan(string kodeJabatan, string namaJabatan)
        {
            return "INSERT INTO taJabatan(KODE_JABATAN, NAMA_JABATAN) VALUES ('" + kodeJabatan + "', '" + namaJabatan + "')";
        }
        public static string getQueryUpdatejabatan(string kodeJabtan,string namaJabatan)
        {
            return "UPDATE taJabatan SET NAMA_JABATAN = '"+namaJabatan+"' WHERE (KODE_JABATAN = '"+kodeJabtan+"')";
        }
        public static string getQueryDeleteJabatan(string kodeJabatan)
        {
            return "DELETE FROM taJabatan WHERE (KODE_JABATAN = '"+kodeJabatan+"')";
        }
    }
}
