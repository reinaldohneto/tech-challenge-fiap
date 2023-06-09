using Fiap.TechChallenge.Domain.Entities.Memes;
using Fiap.TechChallenge.Infra.Maps.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Infra.Maps.Memes;

public class MemeMap : EntityMap<Meme>
{
    public override void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.Property(m => m.Id)
            .HasColumnName("Id");

        builder.Property(m => m.Description)
            .HasColumnName("Description")
            .HasColumnType("TEXT");

        builder.Property(m => m.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR(50)");

        builder.Property(m => m.Link)
            .HasColumnName("MemeLink")
            .HasColumnType("VARCHAR(250)");

        builder.Property(m => m.IsVideo)
            .HasColumnName("IsVideo")
            .HasColumnType("BIT");

        builder.ToTable("Memes");

        base.Configure(builder);
    }
}