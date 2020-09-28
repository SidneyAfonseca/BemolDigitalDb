using DataBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dados.Entities
{
    public class Clientes : IEntityBase<Clientes>
    {
        public EfContext EfContext { get; set; }

        public Clientes(EfContext dbContext)
        {
            this.EfContext = dbContext;
        }

        //public int Id { get; set; }
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        //public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        //public string Unidade { get; set; }
        public string Ibge { get; set; }

        //public string Gia { get; set; }

        public Clientes Alterar(Clientes cliente)
        {
            var retorno = Consultar(cliente.Nome);

            retorno.Nome       = cliente.Nome;
            retorno.Cep        = cliente.Cep;
            retorno.Logradouro = cliente.Logradouro;
            retorno.Bairro     = cliente.Bairro;
            retorno.Cidade     = cliente.Cidade;
            retorno.Uf         = cliente.Uf;
            retorno.Ibge       = cliente.Ibge;

            EfContext.Clientes.Update(retorno);
            EfContext.SaveChanges();
            return cliente;
        }

        public Clientes Consultar(string nome)
        {
            return EfContext.Clientes.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public int Incluir(Clientes obj)
        {
            var retorno = Consultar(obj.Nome);

            if (retorno != null)
            {
                retorno = Alterar(obj);
                return 2;
            }
            EfContext.Clientes.Add(obj);
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
            EfContext.Clientes.Remove(retorno);

            return 1;
        }
    }
}
