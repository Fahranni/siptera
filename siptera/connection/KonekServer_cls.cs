using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
//using Mydql.Data.MySqlClient;
using MySql.Data.MySqlClient;
using Sipen.koneksi;
using siptera.connection;


namespace siptera.koneksi
{
    internal class KonekServer_cls:Server_cls
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        static string[] data = Setting_cls.bacaSetting("setting.txt");

        string alamatServer = "server=" + data[0] + ";port=" + data[1] + ";" +
        "database=" + data[2] + ";" +
        "uid=" + data[3] + ";" +
        "pw=" + data[4] + ";";

        public KonekServer_cls()
        {
            conn = new MySqlConnection(alamatServer);
            cmd = new MySqlCommand();
            adapter = new MySqlDataAdapter();
        }


        void openKoneksi()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                } catch (Exception ex) { }
            }
        }

        void closeKoneksi()
        {
            conn?.Close();
        }

        public override int eksekusiNonQuery(string query)
        {
            int retVal = -1;

            try
            {
                openKoneksi();
                cmd.Connection = conn;
                cmd.CommandText = query;
                retVal = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                closeKoneksi();
            }

            return retVal;
        }

        public override DataTable eksekusiQuery(string query)
        {
            DataTable retVal = new DataTable();

            try
            {
                openKoneksi();
                cmd.Connection = conn;
                cmd.CommandText = query;
                adapter.SelectCommand = cmd;
                adapter.Fill(retVal);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                closeKoneksi();
            }

            return retVal;
        }

        public bool testKoneksi()
        {
            try
            {
                openKoneksi();
                if (conn.State == ConnectionState.Open)
                {
                    closeKoneksi();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }

    }
}
