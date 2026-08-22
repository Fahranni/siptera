using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using siptera.connection;

namespace siptera.model
{
    using System.Collections;
    using System.Data;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using siptera.koneksi;
    internal class LihatPengajuan_cls
    {
        KonekServer_cls server = new KonekServer_cls();
        string Query;
        public DataTable GetSemuaPengajuan()//mengambil seluruh data pengajuan dari databbase
        {
            //Data menunggu diurutkan paling atas dan tanggal pengajuan berdasarkan urutan terakhir input
            string query = @"SELECT id_pengajuan, nik, nama, jenis_kelamin,
                CONCAT(tempat_lahir, ', ', DATE_FORMAT(tanggal_lahir, '%e %M %Y')) AS ttl,
                agama, status_perkawinan, pekerjaan,
                CONCAT(alamat, ', RT ', rt, '/RW ', rw) AS alamat_lengkap,
                tanggal_pengajuan, status, alasan_penolakan
                FROM pengajuan_perubahan
                ORDER BY 
                    CASE WHEN status = 'menunggu' THEN 0 ELSE 1 END,
                    tanggal_pengajuan DESC;";//

            return server.eksekusiQuery(query);
        }

        public DataTable GetPengajuanByStatus(string status)//ambil data berdasarkan status
        {
            string query = @"
        SELECT id_pengajuan, nik, nama, jenis_kelamin,
        CONCAT(tempat_lahir, ', ', DATE_FORMAT(tanggal_lahir, '%e %M %Y')) AS ttl,
        agama, status_perkawinan, pekerjaan,
        CONCAT(alamat, ', RT ', rt, '/RW ', rw) AS alamat_lengkap,
        tanggal_pengajuan, status, alasan_penolakan
        FROM pengajuan_perubahan
        WHERE status LIKE '" + status + "%'";//filter berdasarkan status
            
            return server.eksekusiQuery(query);
        }

        public DataTable GetPengajuanByNama(string nama)//ambil data pengajuan berdasarkan nama
        {
            string query = @"
        SELECT id_pengajuan, nik, nama, jenis_kelamin,
        CONCAT(tempat_lahir, ', ', DATE_FORMAT(tanggal_lahir, '%e %M %Y')) AS ttl,
        agama, status_perkawinan, pekerjaan,
        CONCAT(alamat, ', RT ', rt, '/RW ', rw) AS alamat_lengkap,
        tanggal_pengajuan, status, alasan_penolakan
        FROM pengajuan_perubahan
        WHERE nama LIKE '%" + nama + "%'";

            return server.eksekusiQuery(query);
        }
        public DataTable GetPengajuanByAlamat(string nama)//berdasarka alamat
        {
            string query = @"
        SELECT id_pengajuan, nik, nama, jenis_kelamin,
        CONCAT(tempat_lahir, ', ', DATE_FORMAT(tanggal_lahir, '%e %M %Y')) AS ttl,
        agama, status_perkawinan, pekerjaan,
        CONCAT(alamat, ', RT ', rt, '/RW ', rw) AS alamat_lengkap,
        tanggal_pengajuan, status, alasan_penolakan
        FROM pengajuan_perubahan
        WHERE alamat LIKE '" + nama + "%'";

            return server.eksekusiQuery(query);
        }

        public DataRow GetPengajuanById(string idPengajuan)
        {
            string query = $"SELECT * FROM pengajuan_perubahan WHERE id_pengajuan = '{idPengajuan}'";//ambil semua data dari tabel pengajuan perubahan
            DataTable dt = server.eksekusiQuery(query);//menjalankan query ke database dan menyimpan hasilnya
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;//jika ada data kembalikan baris pertama, jika tidak kembalikan null (menyinkronkan ke data tabel lain)
        }

        public bool UpdateStatus(string idPengajuan, string statusBaru, string alasan = null)
        {
            string query;

            if (statusBaru == "ditolak")
            {
                query = $"UPDATE pengajuan_perubahan SET status = '{statusBaru}', alasan_penolakan = '{alasan}' WHERE id_pengajuan = '{idPengajuan}'";
            }
            else
            {
                query = $"UPDATE pengajuan_perubahan SET status = '{statusBaru}', alasan_penolakan = NULL WHERE id_pengajuan = '{idPengajuan}'";
            }

            return server.eksekusiNonQuery(query) > 0;
        }

        public bool SinkronKePenduduk(DataRow row)//menyinkronkan data pengajuan yang sudah disetujui ke tabel penduduk
        {
            string nik = row["nik"].ToString();//mengambil nik dari data pengajuan
            string queryCek = $"SELECT COUNT(*) FROM penduduk WHERE nik = '{nik}'";//cek apakah nik ada ditabel
            DataTable cek = server.eksekusiQuery(queryCek);

            if (cek.Rows.Count == 0 || Convert.ToInt32(cek.Rows[0][0]) == 0)//jika nik tidak ditemukan tidak bisa sinkron
                return false;

            //Jika nik ada update seluruh data
            string update = $@"
        UPDATE penduduk SET
            nama = '{row["nama"]}',
            jenis_kelamin = '{row["jenis_kelamin"]}',
            tempat_lahir = '{row["tempat_lahir"]}',
            tanggal_lahir = '{Convert.ToDateTime(row["tanggal_lahir"]).ToString("yyyy-MM-dd")}',
            agama = '{row["agama"]}',
            status_perkawinan = '{row["status_perkawinan"]}',
            pekerjaan = (
                SELECT id_pekerjaan FROM pekerjaan WHERE nama_pekerjaan = '{row["pekerjaan"]}' LIMIT 1
            ),
            alamat = '{row["alamat"]}',
            rt = '{row["rt"]}',
            rw = '{row["rw"]}'
        WHERE nik = '{nik}'";

            return server.eksekusiNonQuery(update) > 0;
        }

        // FUNGSI UNTUK KEPERLUAN STATISTIK
        public DataTable getJumlahStatus()
        {
            Query = "SELECT status, COUNT(*) as jumlah FROM pengajuan_perubahan GROUP BY status";
            return server.eksekusiQuery(Query);
        }

        public DataTable getJumlahPerBulan()
        {
            Query = @"
        SELECT 
            FORMAT(tanggal_pengajuan, 'MMMM yyyy') AS Bulan, 
            COUNT(*) AS Jumlah 
        FROM pengajuan_perubahan 
        GROUP BY FORMAT(tanggal_pengajuan, 'MMMM yyyy') 
        ORDER BY MIN(tanggal_pengajuan)";

            return server.eksekusiQuery(Query);
        }


    }
}


