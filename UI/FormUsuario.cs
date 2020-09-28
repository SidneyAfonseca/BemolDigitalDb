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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            this.txbNome.Focus();
        }

        private void mskTxbCep_Leave(object sender, EventArgs e)
        {

        }

        private void mskTxbCep_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (true)
            {
                MessageBox.Show("Usuário salvo com sucesso!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txbNome_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
