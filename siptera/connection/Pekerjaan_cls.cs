using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siptera.model
{
    using System.Collections;
    using System.Data;
    using connection;
    using Siptera.koneksi;

    internal class Pekerjaan_cls
    {
        private string id_pekerjaan;
        private string nama_pekerjaan;

        KonekServer_cls server;
        String Query;

        public Pekerjaan_cls() 
        {
            id_pekerjaan = "";
            nama_pekerjaan = "";
            server = new KonekServer_cls();
            Query = "";
        }
        public string Id_pekerjaan
        {
            set { id_pekerjaan = value; } //mutator method
            get { return id_pekerjaan; } //aksesor method
        }

        public string Nama_pekerjaan
        {
            set { nama_pekerjaan = value; }
            get { return nama_pekerjaan; }
        }
        public bool isExist(string id_pekerjaan)
        {
            bool cek = false;
            Query = "SELECT * FROM pekerjaan WHERE id_pekerjaan = '" + id_pekerjaan + "'";

            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }
        public int saveData()
        {
            int result = -1;
            Query = "INSERT INTO pekerjaan (nama_pekerjaan) VALUES ('" + nama_pekerjaan + "')";
            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public int updateData(string id)
        {
            int result = -1;
            Query = "UPDATE pekerjaan SET nama_pekerjaan='" + nama_pekerjaan + "'" + "WHERE id_pekerjaan = '" + id + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public DataTable tampilSemua()
        {
            Query = "SELECT id_pekerjaan, nama_pekerjaan FROM pekerjaan";

            return server.eksekusiQuery(Query);
        }

        public DataTable tampilByNama(String nama_pekerjaan)
        {
            Query = "select * from pekerjaan where nama_pekerjaan like '%" + nama_pekerjaan + "%'";
            return server.eksekusiQuery(Query);
        }
        public int deleteData(string id)
        {
            int result = -1;
            Query = "DELETE from pekerjaan WHERE nama_pekerjaan = '" + id + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public string ambilNama(string id)
        {
            string nama_pekerjaan = "";
            DataTable data = new DataTable();
            Query = "select nama_pekerjaan from pekerjaan where nama_pekerjaan = '" + id + "'";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    nama_pekerjaan = row[0].ToString();
                }
            }

            return nama_pekerjaan;
        }
    }
}
