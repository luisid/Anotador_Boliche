using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotador_Boliche
{
    public class Manejador
    {
        public Marcador PrimerJugador = new Marcador();
        public Marcador SegundoJugador = new Marcador();
        public Manejador(string FileLocation)
        {
            Split_Array_Lanzamientos(LeerArchivo.Leer_Archivo(FileLocation));
        }
        private void Split_Array_Lanzamientos(string[] arr)
        {
            string[] a = new string[21];
            string[] b = new string[21];
            for (int i = 0, j = 0, k = 0; i < 21; i++)
            {
                if (i < 18)
                {
                    a[j++] = arr[2 * i - (1 * (i % 2))];
                    b[k++] = arr[2 * i - (1 * (i % 2)) + 2];
                }
                else
                {
                    a[j++] = arr[2 * i - i - 18];
                    b[k++] = arr[2 * i + 21 - i];
                }
            }
            PrimerJugador.generarLanzamientos(a);
            SegundoJugador.generarLanzamientos(b);
            PrimerJugador.generarAcumulado();
            SegundoJugador.generarAcumulado();
        }
    }
}
