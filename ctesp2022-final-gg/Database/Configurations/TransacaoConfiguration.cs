using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.Database.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasData
            (
                new Transacao
                {
                    TransacaoId = 1,
                    Dia = DateTime.Now.AddDays(-2),
                    Valor = 100,
                    ContaBancariaId = 1,
                    TipoTransacaoId = 1
                },
                new Transacao
                {
                    TransacaoId = 2,
                    Dia = DateTime.Now.AddDays(-1),
                    Valor = 200,
                    ContaBancariaId = 2,
                    TipoTransacaoId = 1
                }
                );
        }
    }
}
