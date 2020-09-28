using Business.Controllers;
using Business.Interface;
using Dados;
using Dados.Entities;
using FindCep;
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
            BuscaCepRequest requestCep;
           
            try
            {
                requestCep = new BuscaCepRequest();

                var retorno = requestCep.Pesquisar(mskTxbCep.Text);

                CarregarDadosCep(retorno);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.ToString().Contains("400 (Bad Request)"))
                {
                    MessageBox.Show(this, "CEP inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    mskTxbCep.Clear();
                    mskTxbCep.Focus();

                }
            }
        }
       
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txbNome.Text == "" )
            {
                MessageBox.Show("Informe o nome do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbNome.Focus();
                return;
            }
            else if (txbSenha.Text == "")
            {
                MessageBox.Show("Informe a senha do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbSenha.Focus();
                return;
            }
            else if (mskTxbCep.Text == "")
            {
                MessageBox.Show("Informe o cep do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mskTxbCep.Focus();
                return;
            }

           var ret = UsuariosController.SalvarUsuario(this.txbNome.Text,this.txbSenha.Text,this.mskTxbCep.Text
               ,this.txbLograd.Text,txbBairro.Text,this.txbCidade.Text,this.txbEstado.Text);

                
            if (ret ==1 || ret == 0)
            {
                MessageBox.Show(this, string.Format("Usuário {0} com sucesso!", ret == 1 ? "incluído" : "alterado"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Não foi possível slavar o usuário", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

       

        private void CarregarDadosCep(BuscaCepResponse response)
        {
            mskTxbCep.Text = response.Cep;
            txbLograd.Text = response.Logradouro;
            txbBairro.Text = response.Bairro;
            txbCidade.Text = response.Cidade;
            txbEstado.Text = response.Uf;
        }

      
       
    }
}
