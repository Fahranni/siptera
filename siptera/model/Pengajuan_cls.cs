using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using siptera.connection;

namespace siptera.model
{
    using System.Data;
    using System.Windows.Forms;
    using siptera.koneksi;

    internal class Pengajuan_cls//menyimpan data yang akan dikirimkan ke database
    {
        private string _id_pengajuan;
        private string _id_penduduk;
        private string _nik;
        private string _nama;
        private string _jenis_kelamin;
        private string _tempat_lahir;
        private string _tanggal_lahir;
        private string _agama;
        private string _status_pekawinan;
        private string _pekerjaan;
        private string _alamat;
        private string _rt;
        private string _rw;
        private string _tanggal_pengajuan;
        private string _status;
        private string _alasan_penolakan;

        KonekServer_cls server;

        string Query;


        public Pengajuan_cls()//data awal dan koneksi sebelum diisi
        {
            _id_pengajuan = " ";
            _id_penduduk = " ";
            _nik = " ";
            _nama = " ";
            _jenis_kelamin = " ";
            _tempat_lahir = " ";
            _agama = " ";
            _status_pekawinan = " ";
            _pekerjaan = " ";
            _alamat = " ";
            _rt = " ";
            _rw = " ";
            _tanggal_pengajuan = " ";
            _status = " ";
            _alasan_penolakan = " ";

            server = new KonekServer_cls();
            Query = " ";
        }

        public string Id_pengajuan//mengakses, mengubah
        {
            set { _id_pengajuan = value; }
            get { return _id_pengajuan; }
        }
        public string Id_penduduk
        {
            set { _id_penduduk = value; }
            get { return _id_penduduk; }
        }

        public string NIK
        {
            set {  _nik = value; }   
            get { return _nik; }
        }

        public string Nama
        {
            set { _nama = value; }
            get { return _nama; }
        }

        public string Jenis_kelamin
        {
            set { _jenis_kelamin = value; }
            get { return _jenis_kelamin; }
        }

        public string Tempat_lahir
        {
            set { _tempat_lahir = value; }
            get { return _tempat_lahir; }
        }

        public string Tanggal_lahir
        {
            set { _tanggal_lahir = value; }
            get { return _tanggal_lahir; }
        }

        public string Agama
        {
            set { _agama = value; }
            get { return _agama; }
        }

        public string Status_perkawinan
        {
            set { _status_pekawinan = value; }
            get { return _status_pekawinan; }
        }

        public string Pekerjaan
        {
            set { _pekerjaan = value; }
            get { return _pekerjaan; }
        }

        public string Alamat
        {
            set { _alamat = value; }
            get { return _alamat; }
        }

        public string RT
        {
            set { _rt = value; }
            get { return _rt; }
        }

        public string RW
        {
            set { _rw = value; }
            get { return _rw; }
        }

        public string Tanggal_pengajuan
        {
            set { _tanggal_pengajuan = value; }
            get { return _tanggal_pengajuan; }
        }

        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }

        public string Alasan_penolakan
        {
            set { _alasan_penolakan = value; }
            get { return _alasan_penolakan; }
        }

        public bool isExist(string id) //cek apakah id sudah ada di tabel
        {
            bool cek = false;
            Query = "SELECT * FROM pengajuan_perubahan WHERE id_pengajuan = '" + id + "'";

            if (server.eksekusiQuery(Query).Rows.Count > 0) 
            {
            cek = true;
            }
            return cek;//function
        }

        public int saveData()
        {
            int result = -1;
            Query = "INSERT INTO pengajuan_perubahan " +
                "(id_penduduk, nik, nama, jenis_kelamin, tempat_lahir, tanggal_lahir, agama, status_perkawinan, pekerjaan, alamat, rt, rw, tanggal_pengajuan, status, alasan_penolakan) " +
                "VALUES (" +
                "'" + _id_penduduk + "', " +
                "'" + _nik + "', " +
                "'" + _nama + "', " +
                "'" + _jenis_kelamin + "', " +
                "'" + _tempat_lahir + "', " +
                "'" + _tanggal_lahir + "', " +
                "'" + _agama + "', " +
                "'" + _status_pekawinan + "', " +
                "'" + _pekerjaan + "', " +
                "'" + _alamat + "', " +
                "'" + _rt + "', " +
                "'" + _rw + "', " +
                "NOW(), " +  
                "'menunggu', " +  // status otomatis menunggu
                "NULL" +  // alasan_penolakan?????
                ")";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }

            return result;

        }
        public string cariIdPendudukDariNIK(string nik)
        {
            string id = "";
            Query = "SELECT id_penduduk FROM penduduk WHERE nik = '" + nik + "'";

            try
            {
                DataTable dt = server.eksekusiQuery(Query);
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["id_penduduk"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari id_penduduk: " + ex.Message);
            }

            return id;
        }
    }

}

