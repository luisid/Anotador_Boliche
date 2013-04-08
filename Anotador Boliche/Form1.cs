﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotadorBoliche
{
    public partial class Form1 : Form
    {

        public List<string> Scores = new List<string>();
        public int counter = 0;
        public int turno_counter = 1;
        public int LanzamientoPJ = 0;
        public int LanzamientoSJ = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public struct frame
        {
            public Label roll1;
            public Label roll2;
            public Label roll3;
            public Label acomulado;
        }
        //private Marcador PrimerJuagdor = new Marcador();
        //private Marcador SegundoJugador = new Marcador();
        frame[] LanzamientosPrimerJugador = new frame[10];
        frame[] LanzamientosSegundoJugador = new frame[10];
        
        private bool turno = false; //Turno del primer jugador si turno = true, turno segundo jugador si es igual a false
        private string FilePath
        {
            get { return this.FilePath; }
            set { this.FilePath = value; }
        }
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            LanzamientosPrimerJugador[0].roll1 = p1_1;
            LanzamientosPrimerJugador[0].roll2 = p1_2;
            LanzamientosPrimerJugador[1].roll1 = p1_3;
            LanzamientosPrimerJugador[1].roll2 = p1_4;
            LanzamientosPrimerJugador[2].roll1 = p1_5;
            LanzamientosPrimerJugador[2].roll2 = p1_6;
            LanzamientosPrimerJugador[3].roll1 = p1_7;
            LanzamientosPrimerJugador[3].roll2 = p1_8;
            LanzamientosPrimerJugador[4].roll1 = p1_9;
            LanzamientosPrimerJugador[4].roll2 = p1_10;
            LanzamientosPrimerJugador[5].roll1 = p1_11;
            LanzamientosPrimerJugador[5].roll2 = p1_12;
            LanzamientosPrimerJugador[6].roll1 = p1_13;
            LanzamientosPrimerJugador[6].roll2 = p1_14;
            LanzamientosPrimerJugador[7].roll1 = p1_15;
            LanzamientosPrimerJugador[7].roll2 = p1_16;
            LanzamientosPrimerJugador[8].roll1 = p1_17;
            LanzamientosPrimerJugador[8].roll2 = p1_18;
            LanzamientosPrimerJugador[9].roll1 = p1_19;
            LanzamientosPrimerJugador[9].roll2 = p1_20;
            LanzamientosPrimerJugador[9].roll3 = p1_21;
            for (int j = 0; j < LanzamientosPrimerJugador.Count(); j++)
            {
                LanzamientosPrimerJugador[j].roll1.Text = "";
                LanzamientosPrimerJugador[j].roll2.Text = "";
                if (LanzamientosPrimerJugador[j].roll3 != null)
                    LanzamientosPrimerJugador[j].roll3.Text = "";
            }

            LanzamientosSegundoJugador[0].roll1 = p2_1;
            LanzamientosSegundoJugador[0].roll2 = p2_2;
            LanzamientosSegundoJugador[1].roll1 = p2_3;
            LanzamientosSegundoJugador[1].roll2 = p2_4;
            LanzamientosSegundoJugador[2].roll1 = p2_5;
            LanzamientosSegundoJugador[2].roll2 = p2_6;
            LanzamientosSegundoJugador[3].roll1 = p2_7;
            LanzamientosSegundoJugador[3].roll2 = p2_8;
            LanzamientosSegundoJugador[4].roll1 = p2_9;
            LanzamientosSegundoJugador[4].roll2 = p2_10;
            LanzamientosSegundoJugador[5].roll1 = p2_11;
            LanzamientosSegundoJugador[5].roll2 = p2_12;
            LanzamientosSegundoJugador[6].roll1 = p2_13;
            LanzamientosSegundoJugador[6].roll2 = p2_14;
            LanzamientosSegundoJugador[7].roll1 = p2_15;
            LanzamientosSegundoJugador[7].roll2 = p2_16;
            LanzamientosSegundoJugador[8].roll1 = p2_17;
            LanzamientosSegundoJugador[8].roll2 = p2_18;
            LanzamientosSegundoJugador[9].roll1 = p2_19;
            LanzamientosSegundoJugador[9].roll2 = p2_20;
            LanzamientosSegundoJugador[9].roll3 = p2_21;

            for (int j = 0; j < LanzamientosSegundoJugador.Count(); j++)
            {
                LanzamientosSegundoJugador[j].roll1.Text = "";
                LanzamientosSegundoJugador[j].roll2.Text = "";
                if (LanzamientosSegundoJugador[j].roll3 != null)
                    LanzamientosSegundoJugador[j].roll3.Text = "";
            }

            LanzamientosPrimerJugador[0].acomulado = p1_A1;
            LanzamientosPrimerJugador[1].acomulado = p1_A2;
            LanzamientosPrimerJugador[2].acomulado = p1_A3;
            LanzamientosPrimerJugador[3].acomulado = p1_A4;
            LanzamientosPrimerJugador[4].acomulado = p1_A5;
            LanzamientosPrimerJugador[5].acomulado = p1_A6;
            LanzamientosPrimerJugador[6].acomulado = p1_A7;
            LanzamientosPrimerJugador[7].acomulado = p1_A8;
            LanzamientosPrimerJugador[8].acomulado = p1_A9;
            LanzamientosPrimerJugador[9].acomulado = p1_A10;

            for (int i = 0; i < LanzamientosPrimerJugador.Count(); i++)
            {
                LanzamientosPrimerJugador[i].acomulado.Text = "";
            }

            LanzamientosSegundoJugador[0].acomulado = p2_A1;
            LanzamientosSegundoJugador[1].acomulado = p2_A2;
            LanzamientosSegundoJugador[2].acomulado = p2_A3;
            LanzamientosSegundoJugador[3].acomulado = p2_A4;
            LanzamientosSegundoJugador[4].acomulado = p2_A5;
            LanzamientosSegundoJugador[5].acomulado = p2_A6;
            LanzamientosSegundoJugador[6].acomulado = p2_A7;
            LanzamientosSegundoJugador[7].acomulado = p2_A8;
            LanzamientosSegundoJugador[8].acomulado = p2_A9;
            LanzamientosSegundoJugador[9].acomulado = p2_A10;
            for (int i = 0; i < LanzamientosSegundoJugador.Count(); i++)
            {
                LanzamientosSegundoJugador[i].acomulado.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //next();
        }
        public void open_new_file(string filename)
        {
            if (textBox1.Text == filename || filename == "")
                return;
            if (this.textBox1.Text != filename)
            {
                textBox1.Text = filename;
            }
        }
        public void read_file()
        {
            // Read a text file using StreamReader
            using (System.IO.StreamReader sr = new System.IO.StreamReader(textBox1.Text))
            {
                String line;
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
            //generarMarcador();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 FileDialog = new Form2();
            FileDialog.mainForm = this;
            FileDialog.ShowDialog();
        }
        private bool line_valid(string line)
        {
            string aceptado = "1234567890";
            for (int i = 0; i < line.Length; i++)
                if (!aceptado.Contains(line[i].ToString()))
                    return false;
            return true;
        }
        //private void generarMarcador()
        //{
        //    turno = false;
        //    turno_counter = 1;
        //    PrimerJuagdor.Turnos.Clear();
        //    SegundoJugador.Turnos.Clear();
        //    while (turno_counter <= 10)
        //        nextTurn();

        //    PrimerJuagdor.generarAcumulado();
        //    SegundoJugador.generarAcumulado();
        //    button3.Enabled = true;
        //    LanzamientoPJ = 0;
        //    LanzamientoSJ = 0;
        //    turno_counter = 0;
        //    turno = true;
        //}
        //private void next()
        //{
        //    button1.Enabled = true;
        //    if (turno)
        //    {
        //        if (LanzamientoPJ == PrimerJuagdor.Turnos[turno_counter].Lanzamientos.Count())
        //        {
        //            turno = !turno;
        //            LanzamientoPJ = 0;
        //        }
        //    }
        //    else
        //    {
        //        if (LanzamientoSJ == SegundoJugador.Turnos[turno_counter].Lanzamientos.Count())
        //        {
        //            LanzamientoSJ = 0;
        //            if (turno_counter < 9)
        //            {
        //                turno_counter++;
        //                turno = !turno;
        //            }
        //        }
        //    }
        //    if (turno)
        //    {
        //        if (LanzamientoPJ == 0)
        //            LanzamientosPrimerJugador[turno_counter].roll1.Text = PrimerJuagdor.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].score;
        //        else if (LanzamientoPJ == 1)
        //            LanzamientosPrimerJugador[turno_counter].roll2.Text = PrimerJuagdor.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].score;
        //        else if (LanzamientoPJ == 2)
        //            LanzamientosPrimerJugador[turno_counter].roll3.Text = PrimerJuagdor.Turnos[turno_counter].Lanzamientos[LanzamientoPJ++].score;
        //        setAcomulado(PrimerJuagdor, LanzamientosPrimerJugador, LanzamientoPJ);
        //    }
        //    else
        //    {
        //        if (LanzamientoSJ == 0)
        //            LanzamientosSegundoJugador[turno_counter].roll1.Text = SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].score;
        //        else if (LanzamientoSJ == 1)
        //            LanzamientosSegundoJugador[turno_counter].roll2.Text = SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].score;
        //        else if (LanzamientoSJ == 2)
        //            LanzamientosSegundoJugador[turno_counter].roll3.Text = SegundoJugador.Turnos[turno_counter].Lanzamientos[LanzamientoSJ++].score;
        //        setAcomulado(SegundoJugador, LanzamientosSegundoJugador, LanzamientoSJ);
        //        if (turno_counter == 9 && LanzamientoSJ == 3)
        //            button3.Enabled = false;
        //    }
        //}
        //private void setAcomulado(Marcador marcador, frame[] LanzamientosJugador, int CurrentLanzamiento)
        //{
        //    for (int i = 0; i < marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].acomulados.Count(); i++)
        //        LanzamientosJugador[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].acomulados[i]].acomulado.Text = Convert.ToString(marcador.Turnos[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento - 1].acomulados[i]].acumulado);
        //}
        //private void removeAcomulado(Marcador marcador, frame[] LanzamientosJugador, int CurrentLanzamiento)
        //{
        //    for (int i = 0; i < marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento].acomulados.Count(); i++)
        //        LanzamientosJugador[marcador.Turnos[turno_counter].Lanzamientos[CurrentLanzamiento].acomulados[i]].acomulado.Text = "";
        //}
        //private void back()
        //{
        //    button3.Enabled = true;
        //    if (turno)
        //    {
        //        if (LanzamientoPJ == 0)
        //        {
        //            turno = !turno;
        //            if (turno_counter != 0)
        //            {
        //                turno_counter--;
        //            }
        //            else
        //                button1.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        if (LanzamientoSJ == 0)
        //        {
        //            turno = !turno;
        //        }
        //    }
        //        if (turno)
        //        {

        //            if (LanzamientosPrimerJugador[turno_counter].roll3 != null && LanzamientosPrimerJugador[turno_counter].roll3.Text != "")
        //            {
        //                LanzamientosPrimerJugador[turno_counter].roll3.Text = "";
        //                LanzamientoPJ = 2;
        //            }
        //            else if (LanzamientosPrimerJugador[turno_counter].roll2.Text != "")
        //            {
        //                LanzamientosPrimerJugador[turno_counter].roll2.Text = "";
        //                LanzamientoPJ = 1;
        //            }
        //            else if (LanzamientosPrimerJugador[turno_counter].roll1.Text != "")
        //            {
        //                LanzamientosPrimerJugador[turno_counter].roll1.Text = "";
        //                LanzamientoPJ = 0;
        //                if (turno_counter == 0)
        //                    button1.Enabled = false;
        //            }
        //            removeAcomulado(PrimerJuagdor, LanzamientosPrimerJugador, LanzamientoPJ);
        //        }
        //        else
        //        {
        //            if (LanzamientosSegundoJugador[turno_counter].roll3 != null && LanzamientosSegundoJugador[turno_counter].roll3.Text != "")
        //            {
        //                LanzamientosSegundoJugador[turno_counter].roll3.Text = "";
        //                LanzamientoSJ = 2;
        //            }
        //            else if (LanzamientosSegundoJugador[turno_counter].roll2.Text != "")
        //            {
        //                LanzamientosSegundoJugador[turno_counter].roll2.Text = "";
        //                LanzamientoSJ = 1;
        //            }
        //            else if (LanzamientosSegundoJugador[turno_counter].roll1.Text != "")
        //            {
        //                LanzamientosSegundoJugador[turno_counter].roll1.Text = "";
        //                LanzamientoSJ = 0;
        //            }
        //            removeAcomulado(SegundoJugador, LanzamientosSegundoJugador, LanzamientoSJ);
        //        }
        //}
        //private void nextTurn()
        //{
        //    turno = !turno;
        //    if (turno)
        //        PrimerJuagdor.add_turno(generar_turno());
        //    else
        //    {
        //        SegundoJugador.add_turno(generar_turno());
        //        turno_counter++;
        //    }
        //}
        //private turno generar_turno()
        //{
        //    turno Turno = new turno();
        //    string score = "";
        //    int i = 0;
        //    int total = 0;
        //    if (turno_counter != 10)
        //    {
        //        do
        //        {
        //            score = score_next();
        //            total += Convert.ToInt32(score);
        //            if (score == "10" && i == 0)
        //            {
        //                Turno.nuevo_lanzamiento("X");
        //                counter++;
        //                return Turno;
        //            }
        //            else if (total == 10 && i == 1)
        //                Turno.nuevo_lanzamiento("/");
        //            else
        //                Turno.nuevo_lanzamiento(score);
        //            i++;
        //        } while (total <= 10 && score != "X" && i < 2);
        //    }
        //    else
        //    {
        //        score = score_next();
        //        if (score == "10")
        //        {
        //            Turno.nuevo_lanzamiento("X");
        //            score = score_next();
        //            if (score == "10")
        //                Turno.nuevo_lanzamiento("X");
        //            else
        //                Turno.nuevo_lanzamiento(score);
        //            score = score_next();
        //            if (score == "10")
        //                Turno.nuevo_lanzamiento("X");
        //            else
        //                Turno.nuevo_lanzamiento(score);
        //        }
        //        else
        //        {
        //            total += Convert.ToInt32(score);
        //            Turno.nuevo_lanzamiento(score);
        //            score = score_next();
        //            total += Convert.ToInt32(score);
        //            if (total == 10)
        //            {
        //                Turno.nuevo_lanzamiento("/");
        //                score = score_next();
        //                if (score == "10")
        //                    Turno.nuevo_lanzamiento("X");
        //                else
        //                    Turno.nuevo_lanzamiento(score);
        //            }
        //            else
        //            {
        //                Turno.nuevo_lanzamiento(score);
        //                counter++;
        //            }
        //        }
        //    }
        //    return Turno;
        //}
        //private string score_next()
        //{
        //    if (Scores.Count() > counter)
        //    {
        //        Console.WriteLine(counter);
        //        return Scores[counter++];
        //    }
        //    else
        //    {
        //        Console.WriteLine("eso no debio pasar");
        //        return "0";
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
        //    back();
        }
    }
}