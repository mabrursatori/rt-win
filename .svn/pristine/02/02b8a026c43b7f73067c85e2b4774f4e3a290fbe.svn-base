using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class querySubBagian
    {
        public static string getQueryCountViewSubBagian = "SELECT COUNT(KODE_SUBBAGIAN) FROM q_Subbagian";
        public static string comboSubbagianFilter(string kodeBagian)
        {
            return "SELECT KODE_SUBBAGIAN as name, NAMA_SUBBAGIAN as content FROM q_Subbagian WHERE KODE_BAGIAN='" + kodeBagian + "'";
        }
        public static string getQueryViewSubBagian(string orderBy,string ascdesc)
        {
            return "SELECT " + AriLib.rowNumberQuery(orderBy, ascdesc) + ",KODE_SUBBAGIAN, NAMA_SUBBAGIAN, KODE_BAGIAN, NAMA_BAGIAN, KODE_BIRO, KODE_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Subbagian ";
        }
        public static string getQueryDetailViewSubBagian(string kodeSubBagian)
        {
            return "SELECT KODE_SUBBAGIAN, NAMA_SUBBAGIAN, KODE_BAGIAN, NAMA_BAGIAN, KODE_BIRO, KODE_DEPUTI, KODE_UNIT, KODE_INSTANSI, KODE_CABANG FROM q_Subbagian WHERE KODE_SUBBAGIAN='" + kodeSubBagian + "'";
        }
        public static string getQueryInsertSubBagian(string kodeSubBagian,string namaSubBagian,string kodeBagian)
        {
            return "INSERT INTO taSubbagian(KODE_SUBBAGIAN, NAMA_SUBBAGIAN, KODE_BAGIAN) VALUES ('" + kodeSubBagian + "','" + namaSubBagian + "', '" + kodeBagian + "')";
        }
        public static string getQueryUpdateSubBagian(string kodeSubBagian, string namaSubBagian, string kodeBagian)
        {
            return "UPDATE taSubbagian SET NAMA_SUBBAGIAN = '" + namaSubBagian + "', KODE_BAGIAN = '" + kodeBagian + "' WHERE (KODE_SUBBAGIAN = '" + kodeSubBagian + "')";
        }
        public static string getQueryDeleteSibBagian(string kodeSubbagian)
        {
            return "DELETE FROM taSubbagian WHERE(KODE_SUBBAGIAN = '" + kodeSubbagian + "')";
        }
        public static string filter(string kodeDeputi, string kodeBiro,string kodeBagian)
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
                    temp += " WHERE KODE_BIRO='" + kodeBiro + "'";
                }
                else
                {
                    temp += " AND KODE_BIRO='" + kodeBiro + "'";
                }
            }
            if (kodeBagian != "")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_BAGIAN='" + kodeBiro + "'";
                }
                else
                {
                    temp += " AND KODE_BAGIAN='" + kodeBiro + "'";
                }
            }
            return temp;
        }
    }
}
