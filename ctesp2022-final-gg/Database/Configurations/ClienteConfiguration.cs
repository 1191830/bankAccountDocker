using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.Database.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasData
            (
                new Cliente
                {
                    ClienteId = 1,
                    NomeCliente = "Antonio",
                    Morada = "Rua Direita 1",
                    Contacto = 123
                },
                new Cliente
                {
                    ClienteId = 2,
                    NomeCliente = "Jose",
                    Morada = "Rua Esquerda 1",
                    Contacto = 456
                }
                );
            
        }
    }
}
