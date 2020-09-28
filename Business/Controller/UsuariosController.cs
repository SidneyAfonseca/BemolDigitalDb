using Business.Interface;
using Dados;
using Dados.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Controllers
{
    public class UsuariosController 
    {
        public static Usuarios ValidarUsuario(string nome ,string senha )
        {
            using (var contexto = new EfContext())
            {
                var usuario = new Usuarios(contexto);
                usuario.ValidarNomeSenha(nome, senha);
                return usuario;
            }

        }

        public static int SalvarUsuario(string nome, string senha,string cep,string end,string bairro ,string cidade ,string estado)
        {
            int retorno = 0;
           
            using (var contexto = new EfContext())
            {
                var user = new Usuarios(contexto);

                user.Nome       = nome;
                user.senha      = senha;
                user.Cep        = cep;
                user.Logradouro = end;
                user.Bairro     = bairro;
                user.Cidade     = cidade;
                user.Uf         = estado;
               
                retorno            = user.Incluir(user);

            }

            return retorno;
        }
   
    }
}
