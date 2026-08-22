using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace siptera.connection
{
    internal class Setting_cls
    {
        public static string[] bacaSetting(string namaFile)
        {
            TextReader file = new StreamReader(namaFile);
            string baca = file.ReadLine();
            string[] data = new string[5];

            int i = 0;
            while (i < 5)
            {
                data[i++] = baca;
                baca = file.ReadLine();
            }

            return data;
        }
    }
}
