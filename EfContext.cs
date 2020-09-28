
using Dados.Entities;
using DataBase;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dados
{
    public class EfContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringSqlServerConection = @"Data Source=DESKTOP-RLH04LV\SQLEXPRESS;Initial Catalog=BemolDigtalDB;ConnectRetryCount=0;Persist Security Info=false;User ID=sa;Password=123";
            
            optionsBuilder.UseSqlServer(stringSqlServerConection);
        }
    }
}
