using Norma.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Norma.Data.Mappings
{
    public class NormaExternaMapping : IEntityTypeConfiguration<NormaExterna>
    {
        public void Configure(EntityTypeBuilder<NormaExterna> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Codigo)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(n => n.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(n => n.Comite)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(n => n.Idioma)
               .IsRequired()
               .HasColumnType("varchar(1000)");

            builder.Property(n => n.TipoNorma)
              .IsRequired();

            builder.Property(n => n.DataPublicacao)
             .IsRequired();

            builder.Property(n => n.DataInicioValidade)
             .IsRequired();

            builder.HasOne(n => n.Arquivo)
              .WithOne(a => a.NormaExterna)
              .HasForeignKey<Arquivo>(a => a.NormaId);


            builder.ToTable("NormasExternas");
        }
    }
}