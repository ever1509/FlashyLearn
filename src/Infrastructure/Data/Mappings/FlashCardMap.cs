using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class FlashCardMap : IEntityTypeConfiguration<FlashCard>
{
    public void Configure(EntityTypeBuilder<FlashCard> builder)
    {
        builder.HasKey(e => e.FlashCardID);
        builder.Property(e => e.FrontText).HasColumnType("varchar(50)");
        builder.Property(e => e.CreatedDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.BackText).HasMaxLength(100);

        builder.HasOne(e => e.Category)
            .WithMany(d => d.FlashCards)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(e => e.CategoryID)
            .HasConstraintName("FK_FlashCard_Category");
        
    }
}