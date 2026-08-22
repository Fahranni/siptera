using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sipen.koneksi;
using siptera.koneksi;

namespace siptera.model
{
    internal class AnggotaKeluarga_cls
    {
        private string _id_keluarga;
        private string _id_penduduk;
        private string _new_id_penduduk;
        private string _hubungan_dalam_keluarga;

        KonekServer_cls server;
        string Query;

        public AnggotaKeluarga_cls()
        {
            _id_keluarga = "";
            _id_penduduk = "";
            _hubungan_dalam_keluarga = "";
            server = new KonekServer_cls();
            Query = "";
        }

        public string Id_keluarga
        {
            set { _id_keluarga = value; }
        }

        public string Id_penduduk
        {
            set { _id_penduduk= value; }
        }

        public string New_penduduk
        {
            set { _new_id_penduduk = value; }
        }

        public string Hubungan_dalam_keluarga
        {
            set { _hubungan_dalam_keluarga = value; }
        }

        public bool isExist(string id)
        {
            bool cek = false;
            Query = "SELECT * FROM anggota_keluarga WHERE id = '" + id + "'";

            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }

        public int saveData()
        {
            int result = -1;
            Query = "INSERT INTO anggota_keluarga (id_keluarga, id_penduduk, hubungan_dalam_keluarga) " +
                    "VALUES('" + _id_keluarga + "', '" + _id_penduduk + "', '" + _hubungan_dalam_keluarga + "')";
            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }

        public int deleteData(string id)
        {
            int result = -1;
            Query = "DELETE from anggota_keluarga WHERE id = '" + id + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }

        //public int cekPenduduk(string id, string idPenduduk)
        //{
        //    int result = -1;
        //    Query = "SELECT from anggota_keluarga WHERE id = "
        //}

        public DataTable tampilSemua()
        {
            Query = @"
        SELECT 
            ak.id_keluarga,
            k.no_kk as no_kk,
            p.nama AS nama_penduduk,
            ak.hubungan_dalam_keluarga,
            ak.id
            FROM anggota_keluarga ak
            JOIN keluarga k ON ak.id_keluarga = k.id_keluarga
            JOIN penduduk p ON ak.id_penduduk = p.id_penduduk";

            return server.eksekusiQuery(Query);
        }
        public DataTable tampilByNama(string keyword)
        {
            Query = @"
        SELECT 
            ak.id_keluarga,
            k.no_kk,
            p.nama AS nama_penduduk,
            ak.hubungan_dalam_keluarga
            FROM anggota_keluarga ak
            JOIN keluarga k ON ak.id_keluarga = k.id_keluarga
            JOIN penduduk p ON ak.id_penduduk = p.id_penduduk
            WHERE p.nama LIKE '%" + keyword + "%'";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilByNIK(string keyword)
        {
            Query = @"
        SELECT 
            ak.id_keluarga,
            k.no_kk,
            p.nama AS nama_penduduk,
            ak.hubungan_dalam_keluarga
            FROM anggota_keluarga ak
            JOIN keluarga k ON ak.id_keluarga = k.id_keluarga
            JOIN penduduk p ON ak.id_penduduk = p.id_penduduk
            WHERE k.no_kk LIKE '" + keyword + "%'";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilByHub(string keyword)
        {
            Query = @"
        SELECT 
            ak.id_keluarga,
            k.no_kk,
            p.nama AS nama_penduduk,
            ak.hubungan_dalam_keluarga
            FROM anggota_keluarga ak
            JOIN keluarga k ON ak.id_keluarga = k.id_keluarga
            JOIN penduduk p ON ak.id_penduduk = p.id_penduduk
            WHERE ak.hubungan_dalam_keluarga LIKE '" + keyword + "%'";

            return server.eksekusiQuery(Query);
        }
        public string ambilNama(string id)
        {
            string nama = "";
            DataTable data = new DataTable();

            Query = @"
            SELECT p.nama as nama_penduduk 
            FROM anggota_keluarga ak nama_keluarga
            JOIN penduduk p ON ak.id_penduduk = p.id_penduduk
            WHERE ak.id_keluarga = '" + id + "'";

            data = server.eksekusiQuery(Query);

            if (data.Rows.Count > 0)
            {
                // Misalnya ambil nama dari anggota pertama saja
                nama = data.Rows[0]["nama"].ToString();
            }

            return nama;
        }
        public int updateData(string id)
        {
            int result = -1;
            Query = "UPDATE anggota_keluarga SET hubungan_dalam_keluarga = '" + _hubungan_dalam_keluarga + 
        //"', hubungan_dalam_keluarga = '" + _hubungan_dalam_keluarga + 
        "' WHERE id = '" + id + "'";


            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public DataTable getJumlahHub()
        {
            Query = "SELECT hubungan_dalam_keluarga, COUNT(*) as jumlah FROM anggota_keluarga GROUP BY hubungan_dalam_keluarga";
            return server.eksekusiQuery(Query);
        }

    }
}
