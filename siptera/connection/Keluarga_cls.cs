using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siptera.model
{
    using System.Data;
    using connection;
    using Siptera.koneksi;

    internal class Keluarga_cls
    {
        private string id_keluarga;
        private string no_kk;
        private string alamat;
        private string rt;
        private string rw;


        KonekServer_cls server;
        String Query;

        public Keluarga_cls()
        {
            id_keluarga = "";
            no_kk = "";
            alamat = "";
            rt = "";
            rw = "";
            server = new KonekServer_cls();
            Query = "";
        }

        public string Id_keluarga
        {
            set { id_keluarga = value; } //mutator method
            get { return id_keluarga; } //aksesor method
        }

        public string No_kk
        {
            set { no_kk = value; }
            get { return no_kk; }
        }
        public string Alamat
        {
            set { alamat = value; }
            get { return alamat; }
        }
        public string RT
        {
            set { rt = value; }
            get { return rt; }
        }
        public string RW
        {
            set { rw = value; }
            get { return rw; }
        }
        public bool isExist(string no_kk)
        {
            bool cek = false;
            Query = "SELECT * FROM keluarga WHERE no_kk = '" + no_kk + "'";

            if (server.eksekusiQuery(Query).Rows.Count > 0)
            {
                cek = true;
            }

            return cek;
        }
        public int saveData()
        {
            int result = -1;
            Query = "INSERT INTO keluarga (no_kk, alamat, rt, rw) " +
                "VALUES('" + no_kk + "', '" + alamat + "', '" + rt + "', '" + rw + "')";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public int updateData(string nokk)
        {
            int result = -1;
            Query = "UPDATE keluarga SET no_kk='" + no_kk + "', " +"alamat='" + alamat + "', rt='" + rt + "', rw='" + rw + "' " +
                "WHERE no_kk = '" + nokk + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public DataTable tampilSemua()
        {
            Query = "SELECT no_kk, alamat, rt, rw FROM keluarga";

            return server.eksekusiQuery(Query);
        }
        
        public DataTable tampilByNomer(String nokk)
        {
            Query = "select * from keluarga where no_kk like '%" + nokk + "%'";
            return server.eksekusiQuery(Query);
        }
        public int deleteData(string id)
        {
            int result = -1;
            Query = "DELETE from keluarga WHERE no_kk = '" + id + "'";

            try
            {
                result = server.eksekusiNonQuery(Query);
            }
            catch (Exception ex) { }

            return result;
        }
        public string ambilnoKK(string id)
        {
            string noKK = "";
            DataTable data = new DataTable();
            Query = "select no_kk from keluarga where id_keluarga = '" + id + "'";
            data = server.eksekusiQuery(Query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    noKK = row[0].ToString();
                }
            }
            return noKK;
        }

    }
}
