using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipen.koneksi;
using siptera.connection;
using siptera.koneksi;

namespace siptera.model
{
        internal class Pengguna_cls
        {
            private KonekServer_cls koneksi;

            public Pengguna_cls()
            {
                koneksi = new KonekServer_cls();
            }

        // Metode untuk validasi login
        public bool LoginValid(string username, string password)
        {
            string query = $"SELECT * FROM pengguna WHERE username = '{username}' AND password = '{password}'";
            DataTable hasil = koneksi.eksekusiQuery(query);

            return hasil.Rows.Count > 0;
        }
        public string CekLoginDanAmbilRole(string username, string password)
        {
            string query = $"SELECT role FROM pengguna WHERE username = '{username}' AND password = '{password}'";
            DataTable hasil = koneksi.eksekusiQuery(query);

            if (hasil.Rows.Count > 0)
            {
                // Login berhasil, ambil nilai role
                return hasil.Rows[0]["role"].ToString();
            }
            else
            {
                // Login gagal
                return null;
            }
        }
        public string AmbilIdPenduduk(string username, string password)
        {
            string query = $"SELECT id_penduduk FROM pengguna WHERE username = '{username}' AND password = '{password}'";
            DataTable hasil = koneksi.eksekusiQuery(query);

            if (hasil.Rows.Count > 0)
            {
                return hasil.Rows[0]["id_penduduk"].ToString();
            }
            else
            {
                return null;
            }
        }
        public string AmbilIdPendudukNIK(string nik)
        {
            string query = $"SELECT id_penduduk FROM penduduk WHERE nik = '{nik}'";
            DataTable hasil = koneksi.eksekusiQuery(query);

            if (hasil.Rows.Count > 0)
            {
                return hasil.Rows[0]["id_penduduk"].ToString();
            }
            else
            {
                return null;
            }
        }


    }
}

