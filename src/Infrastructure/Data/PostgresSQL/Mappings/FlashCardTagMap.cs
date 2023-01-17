using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.PostgresSQL.Mappings
{
    public class FlashCardTagMap : IEntityTypeConfiguration<FlashCardTag>
    {
        public void Configure(EntityTypeBuilder<FlashCardTag> builder)
        {
            builder.HasKey(e => new { e.TagID, e.Id });

            builder
                .HasOne(sc => sc.FlashCard)
                .WithMany(s => s.FlashCardTags)
                .HasForeignKey(sc => sc.Id);


            builder
                .HasOne(sc => sc.Tag)
                .WithMany(s => s.FlashCardTags)
                .HasForeignKey(sc => sc.TagID);
        }
    }
}
