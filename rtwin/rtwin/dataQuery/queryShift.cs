﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtwin.dataQuery
{
    class Queryshift
    {
        public static string getQueryCountDataGridShiftHarian = "SELECT COUNT(KODE_SHIFT) from taPola WHERE (SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'N')";
        public static string queryShiftDropdown = "SELECT [KODE_RANGE] AS name,'[' + [KODE_RANGE] + ']' + ' : ' + substring( convert(char(20),[JAM_AWAL],108),1,5) + ' s/d ' + substring(convert(char(20),[JAM_AKHIR],108),1,5) AS content FROM [taRange]";
        public static string getQueryCountDataGridShiftMingguan = "select count(KODE_SHIFT) from taPola WHERE(SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'M') ";
        public static string getQueryDataGridShiftHarian(string orderBy, string ascdesc)
        {
            return "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID,taPola.KODE_SHIFT, taPola.TGL_MULAI, taPola.NAMA_GROUP, taPola.LIBUR_NASIONAL, CASE WHEN LIBUR_NASIONAL = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_LIBUR, CASE WHEN taPola.KODE_DEPARTEMEN = '---' THEN 'GLOBAL' ELSE taCabang.NAMA_CABANG END AS NAMA_CABANG, SUBSTRING(taPola.FORMAT, 1, 2) AS h01, SUBSTRING(taPola.FORMAT, 3, 2) AS h02, SUBSTRING(taPola.FORMAT, 5, 2) AS h03, SUBSTRING(taPola.FORMAT, 7, 2) AS h04, SUBSTRING(taPola.FORMAT, 9, 2) AS h05, SUBSTRING(taPola.FORMAT, 11, 2) AS h06, SUBSTRING(taPola.FORMAT, 13, 2) AS h07, SUBSTRING(taPola.FORMAT, 15, 2) AS h08, SUBSTRING(taPola.FORMAT, 17, 2) AS h09, SUBSTRING(taPola.FORMAT, 19, 2) AS h10, SUBSTRING(taPola.FORMAT, 21, 2) AS h11, SUBSTRING(taPola.FORMAT, 23, 2) AS h12, SUBSTRING(taPola.FORMAT, 25, 2) AS h13, SUBSTRING(taPola.FORMAT, 27, 2) AS h14, SUBSTRING(taPola.FORMAT, 29, 2) AS h15, SUBSTRING(taPola.FORMAT, 31, 2) AS h16, SUBSTRING(taPola.FORMAT, 33, 2) AS h17, SUBSTRING(taPola.FORMAT, 35, 2) AS h18, SUBSTRING(taPola.FORMAT, 37, 2) AS h19, SUBSTRING(taPola.FORMAT, 39, 2) AS h20, SUBSTRING(taPola.FORMAT, 41, 2) AS h21, SUBSTRING(taPola.FORMAT, 43, 2) AS h22, SUBSTRING(taPola.FORMAT, 45, 2) AS h23, SUBSTRING(taPola.FORMAT, 47, 2) AS h24, SUBSTRING(taPola.FORMAT, 49, 2) AS h25, SUBSTRING(taPola.FORMAT, 51, 2) AS h26, SUBSTRING(taPola.FORMAT, 53, 2) AS h27, SUBSTRING(taPola.FORMAT, 55, 2) AS h28, SUBSTRING(taPola.FORMAT, 57, 2) AS h29, SUBSTRING(taPola.FORMAT, 59, 2) AS h30, SUBSTRING(taPola.FORMAT, 61, 2) AS h31, taPola.KODE_DEPARTEMEN FROM taPola LEFT OUTER JOIN taCabang ON taPola.KODE_DEPARTEMEN = taCabang.KODE_CABANG WHERE (SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'N')";
        }
        public static string getQueryDataGridShiftHarianDetail(string kodeShift)
        {
            return "SELECT taPola.KODE_SHIFT, taPola.TGL_MULAI, taPola.NAMA_GROUP, taPola.LIBUR_NASIONAL, CASE WHEN LIBUR_NASIONAL = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_LIBUR, CASE WHEN taPola.KODE_DEPARTEMEN = '---' THEN 'GLOBAL' ELSE taCabang.NAMA_CABANG END AS NAMA_CABANG, SUBSTRING(taPola.FORMAT, 1, 2) AS h01, SUBSTRING(taPola.FORMAT, 3, 2) AS h02, SUBSTRING(taPola.FORMAT, 5, 2) AS h03, SUBSTRING(taPola.FORMAT, 7, 2) AS h04, SUBSTRING(taPola.FORMAT, 9, 2) AS h05, SUBSTRING(taPola.FORMAT, 11, 2) AS h06, SUBSTRING(taPola.FORMAT, 13, 2) AS h07, SUBSTRING(taPola.FORMAT, 15, 2) AS h08, SUBSTRING(taPola.FORMAT, 17, 2) AS h09, SUBSTRING(taPola.FORMAT, 19, 2) AS h10, SUBSTRING(taPola.FORMAT, 21, 2) AS h11, SUBSTRING(taPola.FORMAT, 23, 2) AS h12, SUBSTRING(taPola.FORMAT, 25, 2) AS h13, SUBSTRING(taPola.FORMAT, 27, 2) AS h14, SUBSTRING(taPola.FORMAT, 29, 2) AS h15, SUBSTRING(taPola.FORMAT, 31, 2) AS h16, SUBSTRING(taPola.FORMAT, 33, 2) AS h17, SUBSTRING(taPola.FORMAT, 35, 2) AS h18, SUBSTRING(taPola.FORMAT, 37, 2) AS h19, SUBSTRING(taPola.FORMAT, 39, 2) AS h20, SUBSTRING(taPola.FORMAT, 41, 2) AS h21, SUBSTRING(taPola.FORMAT, 43, 2) AS h22, SUBSTRING(taPola.FORMAT, 45, 2) AS h23, SUBSTRING(taPola.FORMAT, 47, 2) AS h24, SUBSTRING(taPola.FORMAT, 49, 2) AS h25, SUBSTRING(taPola.FORMAT, 51, 2) AS h26, SUBSTRING(taPola.FORMAT, 53, 2) AS h27, SUBSTRING(taPola.FORMAT, 55, 2) AS h28, SUBSTRING(taPola.FORMAT, 57, 2) AS h29, SUBSTRING(taPola.FORMAT, 59, 2) AS h30, SUBSTRING(taPola.FORMAT, 61, 2) AS h31, taPola.KODE_DEPARTEMEN FROM taPola LEFT OUTER JOIN taCabang ON taPola.KODE_DEPARTEMEN = taCabang.KODE_CABANG WHERE (SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'N') AND taPola.KODE_SHIFT='" + kodeShift + "'";
        }
        
        public static string getQueryDataGridShiftMingguan(string orderBy, string ascdesc)
        {
            return "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + ascdesc + ") AS ROWID,taPola.KODE_SHIFT, taPola.NAMA_GROUP, taPola.LIBUR_NASIONAL, CASE WHEN taPola.LIBUR_NASIONAL = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_LIBUR,CASE WHEN taPola.KODE_DEPARTEMEN = '---' THEN 'GLOBAL' ELSE taCabang.NAMA_CABANG END AS NAMA_CABANG, SUBSTRING(taPola.FORMAT, 1, 2) AS Minggu,SUBSTRING(taPola.FORMAT, 3, 2) AS Senin, SUBSTRING(taPola.FORMAT, 5, 2) AS Selasa, SUBSTRING(taPola.FORMAT, 7, 2) AS Rabu,SUBSTRING(taPola.FORMAT, 9, 2) AS Kamis, SUBSTRING(taPola.FORMAT, 11, 2) AS Jumat, SUBSTRING(taPola.FORMAT, 13, 2) AS Sabtu,taPola.KODE_DEPARTEMEN FROM taPola LEFT OUTER JOIN taCabang ON taPola.KODE_DEPARTEMEN = taCabang.KODE_CABANG WHERE(SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'M') ";

        }
        public static string getQueryDeleteShify(string kodeShift)
        {
            return "DELETE FROM taPola Where KODE_SHIFT='" + kodeShift + "'";
        }
        public static string getQUeryInsertShift(string kodeShift,string namaGrup,bool chkLiburNasional,string format,string kodeDepartemen,string tgl)
        {
            if (tgl == "")
            {
                tgl = "GETDATE()";
            }
            else
            {
                tgl = "'" + tgl + "'";
            }
            return "INSERT INTO taPola(KODE_SHIFT, TGL_MULAI, NAMA_GROUP, LIBUR_NASIONAL, FORMAT, KODE_DEPARTEMEN) VALUES('" + kodeShift + "', " + tgl + ", '" + namaGrup + "', '" + chkLiburNasional + "', '" + format + "', '" + kodeDepartemen + "')";
        }
        public static string getQueryUpdateShift(string kodeShift, string namaGrup, bool chkLiburNasional, string format, string kodeDepartemen,string tgl)
        {
            if (tgl != "")
            {
                tgl = ",TGL_MULAI='"+tgl+"'";
            }

            return "UPDATE taPola SET NAMA_GROUP = '" + namaGrup + "', LIBUR_NASIONAL = '" + chkLiburNasional + "',FORMAT = '" + format + "', KODE_DEPARTEMEN='" + kodeDepartemen + "'" + tgl + " WHERE (KODE_SHIFT = '" + kodeShift + "')";
        }
       
    }
}