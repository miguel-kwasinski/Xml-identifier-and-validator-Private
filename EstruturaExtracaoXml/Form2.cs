using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstruturaExtracaoXml
{
    public partial class Form2 : Form
    {
        string eventoGlobal = "", versaoGlobal = "";
        public Form2(string evento, string versao)
        {
            InitializeComponent();
            eventoGlobal = evento;
            versaoGlobal = versao;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ExibeResultado.Text = "Evento: " + eventoGlobal + "  Versão: " + versaoGlobal ;
        }
    }
}
