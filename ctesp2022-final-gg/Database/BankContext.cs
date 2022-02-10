using ctesp2022_final_gg.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.Database
{
    public class BankContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<TipoTransacao> TipoTransacao { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Banco;User Id=sa;Password=MsSqlPwd123!!!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoTransacaoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ContaBancariaConfiguration());
            modelBuilder.ApplyConfiguration(new TransacaoConfiguration());
        }

    }


}
