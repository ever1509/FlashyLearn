using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.PostgresSQL.Mappings
{
    public class FlashCardMap : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.Property(e => e.FrontText).HasColumnType("text");
            builder.Property(e => e.CreatedDate).HasColumnType("timestamp").IsRequired();
            builder.Property(e => e.BackText).HasColumnType("text");
            
            builder.OwnsOne(flashcard => flashcard.Category);

            builder.HasOne(e => e.Category)
                .WithMany(d => d.FlashCards);
        }
    }
}
