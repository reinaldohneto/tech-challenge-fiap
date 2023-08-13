using Fiap.TechChallenge.Domain.Entities.Noticias;
using Fiap.TechChallenge.Infra.Maps.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Infra.Maps.Noticias;

public class NoticiaMap : EntityMap<Noticia>
{
    public override void Configure(EntityTypeBuilder<Noticia> builder)
    {
        builder.Property(m => m.Id)
            .HasColumnName("Id");

        builder.Property(m => m.Titulo)
            .HasColumnName("Titulo")
            .HasColumnType("VARCHAR(100)");

        builder.Property(m => m.Descricao)
            .HasColumnName("Description")
            .HasColumnType("TEXT");

        builder.Property(m => m.Chapeu)
            .HasColumnName("Chapeu")
            .HasColumnType("VARCHAR(250)");

        builder.Property(m => m.Autor)
            .HasColumnName("Autor")
            .HasColumnType("VARCHAR(100)");

        builder.ToTable("Noticias");

        base.Configure(builder);
    }
}