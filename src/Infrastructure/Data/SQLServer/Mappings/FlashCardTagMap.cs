using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.SQLServer.Mappings;

public class FlashCardTagMap : IEntityTypeConfiguration<FlashCardTag>
{
    public void Configure(EntityTypeBuilder<FlashCardTag> builder)
    {
        builder.HasKey(e => new { e.TagID, e.FlashCardID });

        builder
            .HasOne(sc => sc.FlashCard)
            .WithMany(s => s.FlashCardTags)
            .HasForeignKey(sc => sc.FlashCardID);


        builder
            .HasOne(sc => sc.Tag)
            .WithMany(s => s.FlashCardTags)
            .HasForeignKey(sc => sc.TagID);
    }
}