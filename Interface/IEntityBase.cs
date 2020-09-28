using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Interfaces
{
    public interface IEntityBase<T> where T : class
    {
        public EfContext EfContext { get;  set; }
        int Incluir(T obj);
        T Consultar(string a);
        T Alterar(T obj);
        int Remover(string a);
    }
}
