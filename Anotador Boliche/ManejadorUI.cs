using AnotadorBoliche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anotador_Boliche
{
    public class ManejadorUI
    {
        Form1 form1;
        public int counter = 0;
        public int turno_counter = 0;
        public int LanzamientoPJ = 0;
        public int LanzamientoSJ = 0;
        private bool turno = true;
        public ManejadorUI(Form1 form1)
        {
            this.form1 = form1;
        }
        public void next()
        {
            form1.button1.Enabled = true;
            if (turno)
            {
                if (LanzamientoPJ == form1.manejador.PrimerJugador.Turnos[turno_counter].Lanzamientos.Count())
                {
                    turno = !turno;
                    LanzamientoPJ = 0;
                }
            }
            else
            {
                if (LanzamientoSJ == form1.manejador.SegundoJugador.Turnos[turno_counter].Lanzamientos.Count())
                {
                    LanzamientoSJ = 0;
                    if (turno_counter < 9)
                    {
                        turno_counter++;
                        turno = !turno;
                    }
                }
            }
            if (turno)
            {
                if (LanzamientoPJ == 0)
                    form1.LanzamientosPrimerJugador[turno_counter].roll1.Text = form1.manejador.PrimerJugador.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].lanzamiento;
                else if (LanzamientoPJ == 1)
                    form1.LanzamientosPrimerJugador[turno_counter].roll2.Text = form1.manejador.PrimerJugador.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].lanzamiento;
                else if (LanzamientoPJ == 2)
                    form1.LanzamientosPrimerJugador[turno_counter].roll3.Text = form1.manejador.PrimerJugador.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].lanzamiento;
                setAcomulado(form1.manejador.PrimerJugador, form1.LanzamientosPrimerJugador, LanzamientoPJ);
            }
            else
            {
                if (LanzamientoSJ == 0)
                    form1.LanzamientosSegundoJugador[turno_counter].roll1.Text = form1.manejador.SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].lanzamiento;
                else if (LanzamientoSJ == 1)
                    form1.LanzamientosSegundoJugador[turno_counter].roll2.Text = form1.manejador.SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].lanzamiento;
                else if (LanzamientoSJ == 2)
                    form1.LanzamientosSegundoJugador[turno_counter].roll3.Text = form1.manejador.SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].lanzamiento;
                setAcomulado(form1.manejador.SegundoJugador, form1.LanzamientosSegundoJugador, LanzamientoSJ);
                if (turno_counter == 9 && LanzamientoSJ == 3)
                    form1.button3.Enabled = false;
            }
        }
        private void setAcomulado(Marcador marcador, frame[] LanzamientosJugador, int CurrentLanzamiento)
        {
            for (int i = 0; i < marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].AcomuladosDependientes.Count(); i++)
                LanzamientosJugador[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].AcomuladosDependientes[i]].acomulado.Text = Convert.ToString(marcador.Turnos[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].AcomuladosDependientes[i]].acumulado);
        }
        private void removeAcomulado(Marcador marcador, frame[] LanzamientosJugador, int CurrentLanzamiento)
        {
            for (int i = 0; i < marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento].AcomuladosDependientes.Count(); i++)
                LanzamientosJugador[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento].AcomuladosDependientes[i]].acomulado.Text = "";
        }
        public void back()
        {
            form1.button3.Enabled = true;
            if (turno)
            {
                if (LanzamientoPJ == 0)
                {
                    turno = !turno;
                    if (turno_counter != 0)
                    {
                        turno_counter--;
                    }
                    else
                        form1.button1.Enabled = false;
                }
            }
            else
            {
                if (LanzamientoSJ == 0)
                {
                    turno = !turno;
                }
            }
            if (turno)
            {

                if (form1.LanzamientosPrimerJugador[turno_counter].roll3 != null && form1.LanzamientosPrimerJugador[turno_counter].roll3.Text != "")
                {
                    form1.LanzamientosPrimerJugador[turno_counter].roll3.Text = "";
                    LanzamientoPJ = 2;
                }
                else if (form1.LanzamientosPrimerJugador[turno_counter].roll2.Text != "")
                {
                    form1.LanzamientosPrimerJugador[turno_counter].roll2.Text = "";
                    LanzamientoPJ = 1;
                }
                else if (form1.LanzamientosPrimerJugador[turno_counter].roll1.Text != "")
                {
                    form1.LanzamientosPrimerJugador[turno_counter].roll1.Text = "";
                    LanzamientoPJ = 0;
                    if (turno_counter == 0)
                        form1.button1.Enabled = false;
                }
                removeAcomulado(form1.manejador.PrimerJugador, form1.LanzamientosPrimerJugador, LanzamientoPJ);
            }
            else
            {
                if (form1.LanzamientosSegundoJugador[turno_counter].roll3 != null && form1.LanzamientosSegundoJugador[turno_counter].roll3.Text != "")
                {
                    form1.LanzamientosSegundoJugador[turno_counter].roll3.Text = "";
                    LanzamientoSJ = 2;
                }
                else if (form1.LanzamientosSegundoJugador[turno_counter].roll2.Text != "")
                {
                    form1.LanzamientosSegundoJugador[turno_counter].roll2.Text = "";
                    LanzamientoSJ = 1;
                }
                else if (form1.LanzamientosSegundoJugador[turno_counter].roll1.Text != "")
                {
                    form1.LanzamientosSegundoJugador[turno_counter].roll1.Text = "";
                    LanzamientoSJ = 0;
                }
                removeAcomulado(form1.manejador.SegundoJugador, form1.LanzamientosSegundoJugador, LanzamientoSJ);
            }
        }
    }
}
