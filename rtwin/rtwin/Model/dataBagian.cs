﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.Model
{
    class dataBagian
    {
        public int jumData { set; get; }
        public List<dataDetailBagianView> rows { set; get; }
    }
    class dataDetailBagianView
    {
        public string KODE_BAGIAN { set; get; }
        public string NAMA_BAGIAN { set; get; }
        public string KODE_BIRO { set; get; }
        public string NAMA_BIRO { set; get; }
        public string KODE_DEPUTI { set; get; }
        public string KODE_UNIT { set; get; }
        public string KODE_INSTANSI { set; get; }
        public string KODE_CABANG { set; get; }
    }
    class dataDetailBagianTabel
    {
        public string KODE_BAGIAN { set; get; }
        public string NAMA_BAGIAN { set; get; }
        public string KODE_BIRO { set; get; }
    }
}