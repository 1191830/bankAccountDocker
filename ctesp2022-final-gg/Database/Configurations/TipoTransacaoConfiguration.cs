using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ctesp2022_final_gg.Database.Configurations
{
    public class TipoTransacaoConfiguration : IEntityTypeConfiguration<TipoTransacao>
    {
        public void Configure(EntityTypeBuilder<TipoTransacao> builder)
        {
            builder.ToTable("TipoTransacao");
            builder.HasData
            (
                new TipoTransacao
                {
                    TipoTransacaoId = 1,
                    NomeTipoTransacao = "Credito"
                },
                new TipoTransacao
                {
                    TipoTransacaoId = 2,
                    NomeTipoTransacao = "Debito"
                }
                );
        }
    }
}
