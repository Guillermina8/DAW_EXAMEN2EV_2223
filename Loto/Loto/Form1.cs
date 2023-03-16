using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Examen2EVGP2223 : Form
    {
        private LotoGP2223 miGanadora;
        private TextBox[] combinacion = new TextBox[6]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[6];
        private LotoGP2223 miLoto;

        public LotoGP2223 MiLoto
        {
            get => miLoto;
            set => miLoto = value;
        }
        public LotoGP2223 MiGanadora
        {
            get => miGanadora;
            set => miGanadora = value;
        }

        public Examen2EVGP2223()
        {
            InitializeComponent();
            combinacion[0] = txtNumero1; ganadora[0] = txtGanadora1;
            combinacion[1] = txtNumero2; ganadora[1] = txtGanadora2;
            combinacion[2] = txtNumero3; ganadora[2] = txtGanadora3;
            combinacion[3] = txtNumero4; ganadora[3] = txtGanadora4;
            combinacion[4] = txtNumero5; ganadora[4] = txtGanadora5;
            combinacion[5] = txtNumero6; ganadora[5] = txtGanadora6;
            MiGanadora = new LotoGP2223(); // generamos la combinación ganadora
            for (int i = 0; i < 6; i++)
                ganadora[i].Text = Convert.ToString(MiGanadora.Numeros[i]);

        }

        public Examen2EVGP2223(LotoGP2223 miGanadora)
        {
            this.miGanadora = miGanadora;
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            MiLoto = new LotoGP2223(); // usamos constructor vacío, se genera combinación aleatoria
            for ( int i=0; i<6; i++ )
                combinacion[i].Text = Convert.ToString(MiLoto.Numeros[i]);
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            CalculaCombinacion();
            if(MiLoto.ok)
                MessageBox.Show("Combinación válida");
            else
                MessageBox.Show("Combinación no válida");
        }

        
        private void btComprobar_Click(object sender, EventArgs e)
        {
            CalculaCombinacion();
            if (MiLoto.ok)
            {
                int[] nums;
                nums = new int[6];
                for (int i = 0; i < 6; i++)
                    nums[i] = Convert.ToInt32(combinacion[i].Text);
                int aciertos = MiGanadora.Comprobar(nums);
                if (aciertos < 3)
                    MessageBox.Show("No ha resultado premiada");
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
        private void CalculaCombinacion()
        {
            int[] nums = new int[6];
            for(int i = 0; i < 6; i++)
                nums[i] = Convert.ToInt32(combinacion[i].Text);
            MiLoto = new LotoGP2223(nums);
        }

    }
}
