using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anotador_Boliche
{
    [TestClass]
    public class LeerArchivoUnitTesting
    {
        [TestMethod]
        public void Prueba_Leer_archivo_vacio()
        {
            string s = "C:\\Users\\Luis\\Documents\\Visual Studio 2012\\Projects\\Anotador Boliche\\Anotador_Boliche\\Anotador Boliche\\prueba_1_Archivo_Vacio.txt";
            string[] returningData = LeerArchivo.Leer_Archivo(s);
            Assert.AreEqual(returningData.Length, 0);
        }
        [TestMethod]
        public void Prueba_Leer_archivo_lleno()
        {
            string s = "C:\\Users\\Luis\\Documents\\Visual Studio 2012\\Projects\\Anotador Boliche\\Anotador_Boliche\\Anotador Boliche\\prueba_2_Archivo_Lleno.txt";
            string[] returningData = LeerArchivo.Leer_Archivo(s);
            Assert.AreEqual(returningData.Length, 42);
        }

    }
}
