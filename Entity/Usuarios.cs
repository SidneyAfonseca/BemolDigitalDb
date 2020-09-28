using DataBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dados.Entities
{
    public class Usuarios : IEntityBase<Usuarios>
    {
        public EfContext EfContext { get; set; }

        public Usuarios(EfContext dbContext)
        {
            this.EfContext = dbContext;
        }

       
        [Key]
        public string senha { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }

        public Usuarios Editar(Usuarios usuario)
        {
            var retorno = Consultar(usuario.Nome);

            retorno.Nome       = usuario.Nome;
            retorno.senha      = usuario.senha;
            retorno.Cep        = usuario.Cep;
            retorno.Logradouro = usuario.Logradouro;
            retorno.Bairro     = usuario.Bairro;
            retorno.Cidade     = usuario.Cidade;
            retorno.Uf         = usuario.Uf;
            retorno.Ibge       = usuario.Ibge;

            EfContext.Usuarios.Update(retorno);
            EfContext.SaveChanges();
            return usuario;
        }

        public int Incluir(Usuarios obj)
        {
            var retorno = Consultar(obj.Nome);

            if (retorno != null)
            {
                retorno = Editar(obj);
                return 2;
            }
            EfContext.Usuarios.Add(obj);
            EfContext.SaveChanges();
            return 1;
        }

        public int Remover(string nome)
        {
            var retorno = Consultar(nome);

            if (retorno == null)
            {
                return 0;
            }
            EfContext.Usuarios.Remove(retorno);

            return 1;
        }

        public Usuarios Consultar(string nome)
        {
            return EfContext.Usuarios.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public Usuarios ValidarNomeSenha(string nome,string senha)
        {
            return EfContext.Usuarios.Where(c => c.Nome == nome && c.senha == senha).FirstOrDefault();
        }

        
    }
}
