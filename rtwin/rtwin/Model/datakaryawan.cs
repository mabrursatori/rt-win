using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class datakaryawan
    {
        public string nip { set; get; }
        public string username { set; get; }
        public string nama { set; get; }
        public string namaCabang { set; get; }
        public string gradeID { set; get; }
    }
    class dataKaryawanAktif
    {
        public string jumData { set; get; }
        public List<dataDetailKaryawanAktif> rows { set; get; }
       
    }
    class dataDetailKaryawanAktif
    {
        public string NIP { set; get; }
        public string NAMA { set; get; }
        public string PIN { set; get; }
        public string NAMA_UNIT { set; get; }
        public string NAMA_DEPUTI { set; get; }
        public string NAMA_BIRO { set; get; }
        public string NAMA_BAGIAN { set; get; }
        public string NAMA_SUBBAGIAN { set; get; }
        public string NAMA_JABATAN { set; get; }
        public string NAMA_GOLONGAN { set; get; }
        public string KODE_GRADE { set; get; }
        public string NAMA_ESELON { set; get; }
        public string NAMA_STATUS_PEGAWAI { set; get; }
        public string TMT { set; get; }
        public string AKTIF { set; get; }
        public string NON_AKTIF { set; get; }
        public string TGL_LAHIR { set; get; }
        public string NAMA_GROUP { set; get; }
        public string NOREK_BANK { set; get; }
        public string NIP_BARU { set; get; }
        public string ENROLL { set; get; }
        public string KODE_UNIT { set; get; }
        public string KODE_DEPUTI { set; get; }
        public string KODE_BIRO { set; get; }
        public string KODE_BAGIAN { set; get; }
        public string KODE_SUBBAGIAN { set; get; }
        public string KODE_JABATAN { set; get; }
        public string KODE_GOLONGAN { set; get; }
        public string KODE_STATUS_PEGAWAI { set; get; }
        public string KODE_SHIFT { set; get; }
        public string NPWP { set; get; }
        public string NO_TELP { set; get; }

    }
}
