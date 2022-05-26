using Norma.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Norma.Data.Mappings
{
    public class ArquivoMapping : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.CaminhoArquivo)
               .IsRequired()
               .HasColumnType("varchar(200)");     

            builder.ToTable("Arquivo");
        }
    }
}
