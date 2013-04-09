using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotador_Boliche
{
    class LeerArchivo
    {
        private LeerArchivo()
        {

        }
        static public string[] Leer_Archivo(string FileName)
        {
            List<string> Scores = new List<string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(FileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace(" ", "");
                    if (line_valid(line))
                    {
                        if (Convert.ToInt32(line) <= 10)
                        {
                            Scores.Add(line);
                        }
                    }
                }
            }
            return Scores.ToArray();
        }
        private static bool line_valid(string line)
        {
            string aceptado = "1234567890";
            for (int i = 0; i < line.Length; i++)
                if (!aceptado.Contains(line[i].ToString()))
                    return false;
            return true;
        }
    }
}
