using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.Database.Configurations
{
    public class ContaBancariaConfiguration : IEntityTypeConfiguration<ContaBancaria>
    {

        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("ContaBancaria");
            builder.HasData
            (
                new ContaBancaria
                {
                    ContaBancariaId = 1,
                    NumeroConta = 1,
                    IBAN = "PT50-123",
                    SaldoCorrente = 100,
                    ClienteId = 1
                },
                new ContaBancaria
                {
                    ContaBancariaId = 2,
                    NumeroConta = 2,
                    IBAN = "PT50-456",
                    SaldoCorrente = 200,
                    ClienteId = 2
                }
                );
        }
    }
}
