using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotador_Boliche
{
    class Marcador
    {
        public class Lanzamiento
        {
            public string lanzamiento;
            public List<int> AcomuladosDependientes = new List<int>();
        }
        public class Turno
        {
            public List<Lanzamiento> Lanzamientos;
            public int acumulado;
        }
        public List<Turno> Turnos = new List<Turno>();
        public Marcador(){}
        public void generarLanzamientos(string[] lanzamientos)
        {
            for (int i = 0; i < lanzamientos.Length; i += 2)
            {
                if (i < 18)
                {
                    if (i % 2 == 0)
                    {
                        Turno turno = new Turno();
                        turno.acumulado = 0;
                        turno.Lanzamientos = lanzamientos_Para_Turno(lanzamientos[i], lanzamientos[i + 1], null);
                        nuevoTurno(turno);
                    }
                }
                else
                {
                    Turno turno = new Turno();
                    turno.acumulado = 0;
                    turno.Lanzamientos = lanzamientos_Para_Turno(lanzamientos[i], lanzamientos[i + 1], lanzamientos[i+2]);
                    nuevoTurno(turno);
                    break;
                }
            }
        }
        private List<Lanzamiento> lanzamientos_Para_Turno(string l1, string l2, string l3)
        {
            List<Lanzamiento> lanzamientos = new List<Lanzamiento>();
            if (l3 == null)
            {
                if (l1 == "10")
                {
                    Lanzamiento lanzamiento = new Lanzamiento();
                    lanzamiento.lanzamiento = "X";
                    lanzamientos.Add(lanzamiento);
                    return lanzamientos;
                }
                else
                {
                    Lanzamiento lanzamiento = new Lanzamiento();
                    lanzamiento.lanzamiento = l1;
                    lanzamientos.Add(lanzamiento);
                    lanzamiento = new Lanzamiento();
                    if (Convert.ToInt32(l1) + Convert.ToInt32(l2) == 10)
                        lanzamiento.lanzamiento = "/";
                    else
                        lanzamiento.lanzamiento = l2;
                    lanzamientos.Add(lanzamiento);
                    return lanzamientos;
                }
            }
            else
            {
                if (l1 == "10")
                {
                    Lanzamiento lanzamiento = new Lanzamiento();
                    lanzamiento.lanzamiento = "X";
                    lanzamientos.Add(lanzamiento);
                    if (l2 == "10")
                    {
                        lanzamiento = new Lanzamiento();
                        lanzamiento.lanzamiento = "X";
                        lanzamientos.Add(lanzamiento);
                    }
                    else
                    {
                        lanzamiento = new Lanzamiento();
                        lanzamiento.lanzamiento = l2;
                        lanzamientos.Add(lanzamiento);
                    }
                    if (l3 == "10")
                    {
                        lanzamiento = new Lanzamiento();
                        lanzamiento.lanzamiento = "X";
                        lanzamientos.Add(lanzamiento);
                    }
                    else
                    {
                        lanzamiento = new Lanzamiento();
                        lanzamiento.lanzamiento = l3;
                        lanzamientos.Add(lanzamiento);
                    }
                    return lanzamientos;
                }
                else
                {
                    Lanzamiento lanzamiento = new Lanzamiento();
                    lanzamiento.lanzamiento = l1;
                    lanzamientos.Add(lanzamiento);
                    lanzamiento = new Lanzamiento();
                    if (Convert.ToInt32(l1) + Convert.ToInt32(l2) == 10)
                    {
                        lanzamiento.lanzamiento = "/";
                        lanzamientos.Add(lanzamiento);
                        if (l3 == "10")
                        {
                            lanzamiento = new Lanzamiento();
                            lanzamiento.lanzamiento = "X";
                            lanzamientos.Add(lanzamiento);
                        }
                        else
                        {
                            lanzamiento = new Lanzamiento();
                            lanzamiento.lanzamiento = l3;
                            lanzamientos.Add(lanzamiento);
                        }
                    }
                    else
                    {
                        lanzamiento.lanzamiento = l2;
                        lanzamientos.Add(lanzamiento);
                    }
                    return lanzamientos;
                }
            }
        }
        private void nuevoTurno(Turno turno)
        {
            Turnos.Add(turno);
        }
        public void generarAcumulado()
        {
            for (int i = 0; i < this.Turnos.Count(); i++)
            {
                if (i == 0)
                   Turnos[i].acumulado = 0;
                else
                    this.Turnos[i].acumulado = this.Turnos[i - 1].acumulado;
                if (i != 9)
                {
                    if (this.Turnos[i].Lanzamientos[0].lanzamiento == "X")
                        Chuza(i);
                    else if (this.Turnos[i].Lanzamientos[1].lanzamiento == "/")
                        spare(i);
                    else
                        comun(i);
                }
                else
                {
                    if (this.Turnos[i].Lanzamientos[0].lanzamiento == "X")
                        chuzaUltimoTurno(i);
                    else if (this.Turnos[i].Lanzamientos[1].lanzamiento == "/")
                        spareUltimoTurno(i);
                    else if (this.Turnos[i].Lanzamientos[2].lanzamiento != "/")
                        comun(i);
                }
            }
        }

        private void spareUltimoTurno(int i)
        {
            this.Turnos[i].acumulado += 10;
            if (this.Turnos[i].Lanzamientos[2].lanzamiento == "X")
                this.Turnos[i].acumulado += 10;
            else
                this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i].Lanzamientos[2].lanzamiento);
            this.Turnos[i].Lanzamientos[2].AcomuladosDependientes.Add(i);
        }

        private void chuzaUltimoTurno(int i)
        {
            this.Turnos[i].acumulado += 10;
            if (this.Turnos[i].Lanzamientos[1].lanzamiento == "X")
                this.Turnos[i].acumulado += 10;
            else
                this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i].Lanzamientos[1].lanzamiento);
            if (this.Turnos[i].Lanzamientos.Count() == 3 && this.Turnos[i].Lanzamientos[2].lanzamiento == "X")
                this.Turnos[i].acumulado += 10;
            else if (this.Turnos[i].Lanzamientos.Count() == 3)
                this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i].Lanzamientos[2].lanzamiento);
            this.Turnos[i].Lanzamientos[2].AcomuladosDependientes.Add(i);
        }

        private void comun(int i)
        {
            this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i].Lanzamientos[0].lanzamiento);
            this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i].Lanzamientos[1].lanzamiento);
            this.Turnos[i].Lanzamientos[1].AcomuladosDependientes.Add(i);
        }

        private void spare(int i)
        {
            this.Turnos[i].acumulado += 10;
            if (this.Turnos[i + 1].Lanzamientos[0].lanzamiento == "X")
                this.Turnos[i].acumulado += 10;
            else
                this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i + 1].Lanzamientos[0].lanzamiento);
            this.Turnos[i + 1].Lanzamientos[0].AcomuladosDependientes.Add(i);
        }

        private void Chuza(int i)
        {
            if (this.Turnos[i + 1].Lanzamientos.Count() == 2 || this.Turnos[i + 1].Lanzamientos.Count() == 3)
            {
                if (this.Turnos[i + 1].Lanzamientos[1].lanzamiento == "/")
                    this.Turnos[i].acumulado += 20;
                else
                {
                    this.Turnos[i].acumulado += 10;
                    this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i + 1].Lanzamientos[0].lanzamiento == "X" ? "10" : this.Turnos[i + 1].Lanzamientos[0].lanzamiento);
                    this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i + 1].Lanzamientos[1].lanzamiento == "X" ? "10" : this.Turnos[i + 1].Lanzamientos[1].lanzamiento);
                }
                this.Turnos[i + 1].Lanzamientos[1].AcomuladosDependientes.Add(i);
            }
            else if (this.Turnos[i + 1].Lanzamientos.Count() == 1)
            {
                this.Turnos[i].acumulado += 20;
                if (this.Turnos[i + 2].Lanzamientos[0].lanzamiento == "X")
                    this.Turnos[i].acumulado += 10;
                else
                    this.Turnos[i].acumulado += Convert.ToInt32(this.Turnos[i + 2].Lanzamientos[0].lanzamiento);
                this.Turnos[i + 2].Lanzamientos[0].AcomuladosDependientes.Add(i);
            }
        }
        
    }
}
