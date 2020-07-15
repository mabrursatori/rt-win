
using rtwin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class queryKaryawan
    {
        public static string getAutoCompletekaryawan = "SELECT CONCAT(NAMA,'-',NIP) FROM q_Karyawan";
        public static string getQueryCountKaryawan = "SELECT COUNT(NIP) FROM q_Karyawan";
        public static string getQueryKaryawan(string orderBy,string ascdesc)
        {
            return "SELECT "+AriLib.rowNumberQuery(orderBy,ascdesc)+ ", NIP, PIN, NAMA, NAMA_UNIT, NAMA_DEPUTI, NAMA_BIRO, NAMA_BAGIAN, NAMA_SUBBAGIAN, NAMA_JABATAN, NAMA_GOLONGAN, KODE_GRADE, NAMA_ESELON, NAMA_STATUS_PEGAWAI, TMT, AKTIF, NON_AKTIF, TGL_LAHIR, '[' + KODE_SHIFT + ']' + ' ' + NAMA_GROUP AS NAMA_GROUP, NOREK_BANK, NIP_BARU, CASE WHEN ENROLL = 0 THEN 'Belum' ELSE 'Sudah' END AS ENROLL, KODE_UNIT, KODE_DEPUTI, KODE_BIRO, KODE_BAGIAN, KODE_SUBBAGIAN, KODE_JABATAN, KODE_GOLONGAN, KODE_ESELON, KODE_STATUS_PEGAWAI, KODE_SHIFT,NPWP,NO_TELP FROM q_Karyawan";
        }
        public static string getQueryKaryawanDetail(string nip)
        {
            return "SSELECT NIP, PIN, NAMA, NAMA_UNIT, NAMA_DEPUTI, NAMA_BIRO, NAMA_BAGIAN, NAMA_SUBBAGIAN, NAMA_JABATAN, NAMA_GOLONGAN, KODE_GRADE, NAMA_ESELON, NAMA_STATUS_PEGAWAI, TMT, AKTIF, NON_AKTIF, TGL_LAHIR, '[' + KODE_SHIFT + ']' + ' ' + NAMA_GROUP AS NAMA_GROUP, NOREK_BANK, NIP_BARU, CASE WHEN ENROLL = 0 THEN 'Belum' ELSE 'Sudah' END AS ENROLL, KODE_UNIT, KODE_DEPUTI, KODE_BIRO, KODE_BAGIAN, KODE_SUBBAGIAN, KODE_JABATAN, KODE_GOLONGAN, KODE_ESELON, KODE_STATUS_PEGAWAI, KODE_SHIFT,NPWP,NO_TELP FROM q_Karyawan WHERE NIP='" + nip + "'";
        }
        public static string getQueryInsertKaryawan(string nip,string pin, string nama,string kodeCabang,string kodeInstansi,string kodeUnit,string kodeDeputi,string kodeBiro,string kodeBagian,string kodeSubBagian,string kodeJabatan,string kodeGolongan, string kodeGrade,string kodeEselon,string kodeStatusPegawai,string tmt,string aktif,string nonAktif,string tglLahir,string kodeShift,string norekBank,string nipBaru,string npwp,string noTelp)
        {
            return "INSERT INTO taKaryawan(NIP, PIN, NAMA, KODE_CABANG, KODE_INSTANSI, KODE_UNIT, KODE_DEPUTI, KODE_BIRO, KODE_BAGIAN, KODE_SUBBAGIAN, KODE_JABATAN, KODE_GOLONGAN, KODE_GRADE, KODE_ESELON, KODE_STATUS_PEGAWAI, TMT, AKTIF, NON_AKTIF, TGL_LAHIR, KODE_SHIFT, NOREK_BANK, NIP_BARU, WAKTU_SIMPAN,NPWP,NO_TELP) VALUES ('" + nip + "','" + pin + ",'" + nama + "','" + kodeCabang + "' ,'" + kodeInstansi + "','" + kodeUnit + "','" + kodeDeputi + ",'" + kodeBiro + "','" + kodeBagian + "','" + kodeSubBagian + "','" + kodeJabatan + "','" + kodeGolongan + "' ,'" + kodeGrade + "','" + kodeEselon + "','" + kodeStatusPegawai + "','" + tmt + "','" + aktif + "','" + nonAktif + "','" + tglLahir + "','" + kodeShift + "','" + norekBank + "','" + nipBaru + "',GETDATE() ,'" + npwp + "','" + noTelp + "')";
        }
        public static string getQUeryUpdateKaryawan(string nip, string pin, string nama, string kodeCabang, string kodeInstansi, string kodeUnit, string kodeDeputi, string kodeBiro, string kodeBagian, string kodeSubBagian, string kodeJabatan, string kodeGolongan, string kodeGrade, string kodeEselon, string kodeStatusPegawai, string tmt, string aktif, string nonAktif, string tglLahir, string kodeShift, string norekBank, string nipBaru, string npwp, string noTelp)
        {

            return "UPDATE taKaryawan SET PIN = '" + pin + "', NAMA = '" + nama + "', KODE_CABANG = '" + kodeCabang + "', KODE_INSTANSI = '" + kodeInstansi + "', KODE_UNIT = '" + kodeUnit + "', KODE_DEPUTI = '" + kodeDeputi + "', KODE_BIRO = '" + kodeBiro + "', KODE_BAGIAN = '" + kodeBagian + "', KODE_SUBBAGIAN = '" + kodeSubBagian + "', KODE_JABATAN = '" + kodeJabatan + "', KODE_GOLONGAN = '" + kodeGolongan + "', KODE_GRADE = '" + kodeGrade + "', KODE_ESELON = '" + kodeEselon + "', KODE_STATUS_PEGAWAI = '" + kodeStatusPegawai + "', TMT = '" + tmt + "', AKTIF = '" + aktif + "', NON_AKTIF = '" + nonAktif + "', TGL_LAHIR = '" + tglLahir + "', KODE_SHIFT = '" + kodeShift + "', NOREK_BANK = '" + norekBank + "', NIP_BARU = '" + nipBaru + "', NPWP = '" + npwp + "',NO_TELP='" + noTelp + "' WHERE (NIP = '" + nip + "')";
        }
        public static string getQueryDeleteKAryawan(string nip)
        {
            return "DELETE taKaryawan WHERE NIP='" + nip + "'";
        }
        public static string filterAutoComplete(string username,string gradeID)
        {
            string temp = "";
            if (gradeID == "3")
            {
                if (temp == "")
                {
                    temp += " WHERE KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                }
                else
                {
                    temp += " AND KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                }
            }
            return temp;
        }
        public static string filter(string nip, string kodeDeputi, string kodeBiro,string username,string gradeID)
        {
            string temp = "";
            if (nip != "")
            {
                if (temp == "")
                {
                    temp += " WHERE NIP='" + nip + "'";
                }
                else
                {
                    temp += " AND NIP='" + nip + "'";
                }
            }
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
            else
            {
                if (gradeID == "3")
                {
                    if (temp == "")
                    {
                        temp += " WHERE KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                    }
                    else
                    {
                        temp += " AND KODE_DEPUTI in(select kode_departemen from taOtoritasDepartemen where username = '" + username + "')";
                    }
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
            return temp;
        }
    }
}
