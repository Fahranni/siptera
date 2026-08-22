using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using siptera.connection;
//using GUI;
using siptera.model;

namespace siptera.model
{
    using System.Data;
    using connection;
    using Sipen.koneksi;
    using siptera.koneksi;

    internal class Penduduk_cls
    {
        //private string id_penduduk;
        private string nik;
        private string nama;
        private string jenis_kelamin;
        private string tempat_lahir;
        private string tanggal_lahir;
        private string agama;
        private string status_perkawinan;
        private string pekerjaan;
        private string alamat;
        private string rt;
        private string rw;

        KonekServer_cls server;
        string Query;

        public Penduduk_cls()
        {
            //id_penduduk = "" ;
            nik = "";
            nama = "";
            jenis_kelamin = "";
            tempat_lahir = "";
            tanggal_lahir = "";
            agama = "";
            status_perkawinan = "";
            pekerjaan = "";
            alamat = "";
            rt = "";
            rw = "";
            server = new KonekServer_cls();
            Query = "";
        }

        public string Nik
        {
            set { nik = value; } //mutator method
        }

        public string Nama
        {
            set { nama = value; } //mutator method
        }

        public string Jenis_kelamin
        {
            set { jenis_kelamin = value; }
        }
        public string Tempat_lahir
        {
            set { tempat_lahir = value; }
        }

        public string Tanggal_lahir
        {
            set { tanggal_lahir = value; }
        }
        public string Agama
        {
            set { agama = value; }
        }
        public string Status_perkawinan
        {
            set { status_perkawinan = value; }
        }
        public string Pekerjaan
        {
            set { pekerjaan = value; }
        }
        public string Alamat
        {
            set { alamat = value; }
        }
        public string Rt
        {
            set { rt = value; }
        }
        public string Rw
        {
            set { rw = value; }
        }

        public int resetPassword(string pw, int id)
        {
            Query = "UPDATE pengguna SET password = '" + pw + "' WHERE id_penduduk = " + id;

            return server.eksekusiNonQuery(Query);
        }
        public int saveData()
        {
            int result = -1;
            Query = "INSERT INTO penduduk (nik, nama, jenis_kelamin, tempat_lahir, tanggal_lahir, agama, status_perkawinan, pekerjaan, alamat, rt, rw) VALUES (" +
            "'" + nik + "'," +
            "'" + nama + "'," +
            "'" + jenis_kelamin + "'," +
            "'" + tempat_lahir + "'," +
            "'" + tanggal_lahir + "'," +
            "'" + agama + "'," +
            "'" + status_perkawinan + "'," +
            "'" + pekerjaan + "'," +
            "'" + alamat + "'," +
            "'" + rt + "'," +
            "'" + rw + "')";


            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool isExist(string nik)
        {
            bool cek = false;
            Query = "SELECT * FROM penduduk WHERE nik = '" + nik + "'";

            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public DataTable tampilEdit()
        {
            Query = "SELECT " +
                "nik, " +
                "nama, " +
                "jenis_kelamin, " +
                "tempat_lahir, " +
                "tanggal_lahir, " +
                "agama, " +
                "status_perkawinan, " +
                "pekerjaan, " +
                "alamat, " +
                "rt, " +
                "rw " +
                "FROM penduduk";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilPengajuanPenduduk(string id)
        {
            Query = "SELECT " +
                    "tanggal_pengajuan, " +
                    "status, " +
                    "alasan_penolakan " +
                    "FROM pengajuan_perubahan " +
                    "WHERE id_penduduk = '" + id + "' " +
                    "ORDER BY tanggal_pengajuan DESC";

            return server.eksekusiQuery(Query);
        }

        public string ambilUsername(string id)
        {
            string Query = "SELECT " +
                           "p.nama " +
                           "FROM penduduk p " +
                           "JOIN pengguna pg ON p.id_penduduk = pg.id_penduduk " +
                           "WHERE pg.id_penduduk = '" + id + "'";

            DataTable dt = server.eksekusiQuery(Query);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["nama"].ToString();  // Ambil nilai kolom 'nama'
            }
            else
            {
                return null; // atau "" jika ingin string kosong
            }
        }

        public DataTable tampilSemua()
        {
            Query = "SELECT " +
                "p.nik AS nik, " +
                "p.nama AS nama, " +
                "p.jenis_kelamin AS jenis_kelamin, " +
                "CONCAT(p.tempat_lahir, ', ', DATE_FORMAT(STR_TO_DATE(p.tanggal_lahir, '%Y-%m-%d'), '%d %M %Y')) AS tempat_tanggal_lahir, " +
                "p.agama AS agama, " +
                "p.status_perkawinan AS status_perkawinan, " +
                "k.nama_pekerjaan AS nama_pekerjaan, " +
                "CONCAT(p.alamat, ', RT ', p.rt, ' / RW ', p.rw) AS alamat_lengkap, " +

                // Data mentah (untuk edit)
                "p.tempat_lahir AS tempat_lahir, " +
                "p.tanggal_lahir AS tanggal_lahir, " +
                "p.alamat AS alamat, " +
                "p.rt AS rt, " +
                "p.rw AS rw, " +
                "p.pekerjaan AS id_pekerjaan " + // ini penting untuk comboBox edit
                "FROM penduduk p " +
                "LEFT JOIN pekerjaan k ON p.pekerjaan = k.id_pekerjaan";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilDataPengguna(string id_penduduk)
        {
            Query = "SELECT " +
                "p.id_penduduk AS id_penduduk, " +
                "p.nik AS nik, " +
                "p.nama AS nama, " +
                "p.jenis_kelamin AS jenis_kelamin, " +
                "CONCAT(p.tempat_lahir, ', ', DATE_FORMAT(STR_TO_DATE(p.tanggal_lahir, '%Y-%m-%d'), '%d %M %Y')) AS tempat_tanggal_lahir, " +
                "p.agama AS agama, " +
                "p.status_perkawinan AS status_perkawinan, " +
                "k.nama_pekerjaan AS pekerjaan, " +
                "CONCAT(p.alamat, ', RT ', p.rt, ' / RW ', p.rw) AS alamat_lengkap, " +
                // Tambahan data mentah untuk keperluan edit
                "p.tempat_lahir AS tempat_lahir, " +
                "p.tanggal_lahir AS tanggal_lahir, " +
                "p.alamat AS alamat, " +
                "p.rt AS rt, " +
                "p.rw AS rw " +
                "FROM penduduk p " +
                "LEFT JOIN pekerjaan k ON p.pekerjaan = k.id_pekerjaan " +
                "WHERE p.id_penduduk = '" + id_penduduk + "'";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilDataPekerjaan()
        {
            string query = "SELECT id_pekerjaan, nama_pekerjaan FROM pekerjaan";
            return server.eksekusiQuery(query);
        }


        public int updateData(string nik)
        {
            int result = -1;
            Query = "UPDATE penduduk SET " +
    //"nik = '" + nik + "', " +
    "nama = '" + nama + "', " +
    "jenis_kelamin = '" + jenis_kelamin + "', " +
    "tempat_lahir = '" + tempat_lahir + "', " +
    "tanggal_lahir = '" + tanggal_lahir + "', " +
    "agama = '" + agama + "', " +
    "status_perkawinan = '" + status_perkawinan + "', " +
    "pekerjaan = '" + pekerjaan + "', " +
    "alamat = '" + alamat + "', " +
    "rt = '" + rt + "', " +
    "rw = '" + rw + "' " +  // <--- TANPA koma di akhir
    "WHERE nik = '" + nik + "'";


            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex)
            {
                // Optional: log or show error
            }

            return result;
        }
        public int deleteData(string id)
        {
            int result = -1;
            Query = "DELETE FROM penduduk WHERE nik = '" + id + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public string ambilNama(string nik)
        {
            string nama = "";
            DataTable data = new DataTable();
            Query = "select nama from penduduk where nik = '" + nik + "'";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    nama = row[0].ToString();
                }
            }

            return nama;
        }

        public DataTable getDataPenduduk()
        {
            Query = "SELECT nik, nama, jenis_kelamin FROM penduduk";
            return server.eksekusiQuery(Query);
        }
        public DataTable tampilBynama(string nama)
        {
            //Query = "select *  from penduduk where nama like '%" + nama + "%'";
            Query = "SELECT " +
               "nik, " +
               "nama, " +
               "jenis_kelamin, " +
               "CONCAT(tempat_lahir, ', ', DATE_FORMAT(STR_TO_DATE(tanggal_lahir, '%Y-%m-%d'), '%d %M %Y')) AS tempat_tanggal_lahir, " +
               "agama, " +
               "status_perkawinan, " +
               "pekerjaan, " +
               "CONCAT(alamat, ', RT ', rt, ' / RW ', rw) AS alamat_lengkap, " +
               // Tambahkan data mentah untuk keperluan edit
               "tempat_lahir, " +
               "tanggal_lahir, " +
               "alamat, " +
               "rt, " +
               "rw " +
               "FROM penduduk where nama like '%" + nama + "%'";

            return server.eksekusiQuery(Query);
        }

        // FUNGSI UNTUK KEPERLUAN STATISTIK
        public DataTable getJumlahJenisKelamin()
        {
            Query = "SELECT jenis_kelamin, COUNT(*) as jumlah FROM penduduk GROUP BY jenis_kelamin";
            return server.eksekusiQuery(Query);
        }
        public DataTable getJumlahPerkawinan()
        {
            Query = "SELECT status_perkawinan, COUNT(*) as jumlah FROM penduduk GROUP BY status_perkawinan";
            return server.eksekusiQuery(Query);
        }
        public DataTable getJumlahAgama()
        {
            Query = "SELECT agama, COUNT(*) as jumlah FROM penduduk GROUP BY agama";
            return server.eksekusiQuery(Query);
        }
        public DataTable getJumlahPekerjaan()
        {
            Query = @"SELECT p.nama_pekerjaan as pekerjaan, COUNT(*) AS jumlah
              FROM penduduk pd
              JOIN pekerjaan p ON pd.pekerjaan = p.id_pekerjaan
              GROUP BY p.nama_pekerjaan";
            return server.eksekusiQuery(Query);
        }

    }
}
