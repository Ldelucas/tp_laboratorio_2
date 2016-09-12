using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase05_TP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Calculadora";
        }

                private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //this.txtNumero1.Text = "0";
            //this.txtNumero2.Text = "0";
            this.lblResultado.Text = "";
            

            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            
            

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click_1(object sender, EventArgs e)
        {
            
            double Resultado;
            //creo dos numeros
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);

            //al atributo resultado le asigno el retorno del metodo operar en la clase calculadora
            Resultado = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text);
            //Le asigno lo que guardo resultado para que lo muestre 
            this.lblResultado.Text = Resultado.ToString();
        
        }
    }
}
