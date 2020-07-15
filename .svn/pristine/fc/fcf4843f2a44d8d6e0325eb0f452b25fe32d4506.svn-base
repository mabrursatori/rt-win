using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryStatusPegawai
    {
        public static string getQueryCountStatusPegawai= "SELECT COUNT(KODE_STATUS_PEGAWAI) FROM taStatusPegawai WHERE KODE_STATUS_PEGAWAI <> '0'  ";
        public static string getQueryComboStatus = "SELECT KODE_STATUS_PEGAWAI as name, NAMA_STATUS_PEGAWAI as content FROM taStatusPegawai";
        public static string getQueryStatuspegawai(string orderBy, string ascdesc)
        {
            return "SELECT " + AriLib.rowNumberQuery(orderBy, ascdesc) + ",KODE_STATUS_PEGAWAI, NAMA_STATUS_PEGAWAI FROM taStatusPegawai WHERE KODE_STATUS_PEGAWAI <> '0' ";
        }
        public static string getQueryStatusPegawaiDetail (string kodeStatusPegawai)
        {
            return "SELECT KODE_STATUS_PEGAWAI, NAMA_STATUS_PEGAWAI FROM taStatusPegawai WHERE KODE_STATUS_PEGAWAI ='" + kodeStatusPegawai + "' ORDER BY KODE_STATUS_PEGAWAI";
        }
        public static string getQueryInsertStatusPegawai(string kodeStatusPegawai,string namaStatusPegawai)
        {
            return "INSERT INTO taStatusPegawai(KODE_STATUS_PEGAWAI, NAMA_STATUS_PEGAWAI) VALUES ('" + kodeStatusPegawai + "','" + namaStatusPegawai + "')";
        }
        public static string getQueryUpdateStatusPegawai(string kodeStatusPegawai,string namaStatusPegawai)
        {
            return "UPDATE taStatusPegawai SET NAMA_STATUS_PEGAWAI = '" + namaStatusPegawai + "' WHERE KODE_STATUS_PEGAWAI = '" + kodeStatusPegawai + "'";
        }
        public static string getQueryDeleteStatusPegawai(string kodeStatusPegawai)
        {
            return "DELETE FROM taStatusPegawai WHERE (KODE_STATUS_PEGAWAI = '" + kodeStatusPegawai + "')";
        }
    }
}
