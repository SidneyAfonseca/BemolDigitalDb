using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
        }

        private void btnAcesso_Click(object sender, EventArgs e)
        {
            //Validar usuario e senha 
            string nome  = txbUsuario.Text.Trim();
            string senha = txbSenha.Text.Trim();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
