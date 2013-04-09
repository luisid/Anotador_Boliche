using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotador_Boliche
{
    class Marcador
    {
        struct Lanzamiento
        {
            public string lanzamiento;
            public List<int> AcomuladosDependientes = new List<int>();
        }
        struct Turno
        {
            public List<Lanzamiento> Lanzamientos = new List<Lanzamiento>();
            public int acomulado;
        }
        List<Turno> Turnos = new List<Turno>();
        public Marcador(){}
        private void nuevoTurno(Turno turno)
        {

        }
        public void generarAcomulado()
        {
        
        }
        public void generarLanzamientos()
        {

        }
    }
}
