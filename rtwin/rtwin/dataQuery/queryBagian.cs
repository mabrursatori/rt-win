using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryBagian
    {
        public static string comboBagian = "SELECT KODE_BAGIAN as name, NAMA_BAGIAN as content FROM taBagian ";
        public static string getQueryCountBagian = "SELECT COUNT(KODE_BAGIAN) FROM q_Bagian";
        public static string comboBagianFilter(string kodeBiro)
        {
            return "SELECT KODE_BAGIAN as name, NAMA_BAGIAN as content FROM taBagian WHERE KODE_BIRO='" + kodeBiro + "' OR KODE_BAGIAN='000000'";
        }
        public static string getQueryBagianView(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+", KODE_BAGIAN, NAMA_BAGIAN, KODE_BIRO, NAMA_BIRO, KODE_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Bagian";
        }
        public static string getQueryDetailBagian (string kodeBagian)
        {
            return "SELECT KODE_BAGIAN, NAMA_BAGIAN, KODE_BIRO, NAMA_BIRO, KODE_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Bagian where KODE_BAGIAN='" + kodeBagian + "'";
        }
        public static string getQueryInsertBagian(string kodeBagian,string namaBagian,string kodeBiro)
        {
            return "INSERT INTO taBagian(KODE_BAGIAN, NAMA_BAGIAN, KODE_BIRO) VALUES ('" + kodeBagian + "', '" + namaBagian + "', '" + kodeBiro + "')";
        }
        public static string getQueryUpdateBagian(string kodeBagian,string namaBagian,string kodeBiro)
        {
            return "UPDATE taBagian SET NAMA_BAGIAN = '" + namaBagian + "', KODE_BIRO = '" + kodeBiro + "' WHERE (KODE_BAGIAN = '" + kodeBagian + "')";
        }
        public static string getQueryDeleteBagian(string kodeBagian)
        {
            return "DELETE FROM taBagian WHERE (KODE_BAGIAN = '" + kodeBagian + "')";
        }
        public static string filter(string kodeDeputi,string kodeBiro)
        {
            string temp = "";
            if (kodeDeputi != "")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_DEPUTI='" + kodeDeputi + "'";
                }
                else
                {
                    temp += " AND KODE_DEPUTI='" + kodeDeputi + "'";
                }
            }
            if (kodeBiro != "")
            {
                if (temp == "")
                {
                    temp+= " WHERE KODE_BIRO='" + kodeBiro + "'";
                }
                else
                {
                    temp+= " AND KODE_BIRO='" + kodeBiro + "'";
                }
            }
            return temp;
        }
    }
}
