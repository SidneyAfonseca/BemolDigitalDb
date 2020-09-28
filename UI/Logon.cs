using Business.Controllers;
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
            string nome = txbUsuario.Text.Trim();
            string senha = txbSenha.Text.Trim();


            var retUs = UsuariosController.ValidarUsuario(nome, senha);

            if (retUs.Nome == nome && retUs.senha == senha)
            {
                MessageBox.Show("Usuário validado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Usuário não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCad.Focus();
            }
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
