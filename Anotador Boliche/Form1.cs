using Anotador_Boliche;
using System;
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
    public struct frame
    {
        public Label roll1;
        public Label roll2;
        public Label roll3;
        public Label acomulado;
    }
    public partial class Form1 : Form
    {
        public Manejador manejador;
        public ManejadorUI manejadorUI;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public frame[] LanzamientosPrimerJugador = new frame[10];
        public frame[] LanzamientosSegundoJugador = new frame[10];
        
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
            manejadorUI.next();
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
        private void button1_Click(object sender, EventArgs e)
        {
            manejadorUI.back();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            manejador = new Manejador(textBox1.Text);
            manejadorUI = new ManejadorUI(this);
            button1.Enabled = false;
            button3.Enabled = true;
        }
    }
}
