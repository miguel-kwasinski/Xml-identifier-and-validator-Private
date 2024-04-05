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
        private identificaEvento.EventoInfo evtInfo = new identificaEvento.EventoInfo(); 
        public Form2(identificaEvento.EventoInfo eventoInfo)
        {
            InitializeComponent();
            evtInfo = eventoInfo;
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ExibeResultado.Text = "Evento: " + evtInfo.TipoEvento + "  Versão: " + evtInfo.Versao;
        }
    }
}
