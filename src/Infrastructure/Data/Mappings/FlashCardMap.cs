using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class FlashCardMap : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasKey(e => e.FlashCardId);
            builder.Property(e => e.FlashCardId).HasColumnType("uuid");
            builder.Property(e => e.FrontText).HasColumnType("text");
            builder.Property(e => e.CreatedDate).HasColumnType("timestamp").IsRequired();
            builder.Property(e => e.BackText).HasColumnType("text");
            builder.HasOne(e => e.Category)
                .WithMany(d => d.FlashCards);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.FlashCards);
        }
    }
}
