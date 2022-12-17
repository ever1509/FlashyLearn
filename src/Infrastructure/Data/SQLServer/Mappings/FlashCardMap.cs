using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.SQLServer.Mappings;

public class FlashCardMap : IEntityTypeConfiguration<FlashCard>
{
    public void Configure(EntityTypeBuilder<FlashCard> builder)
    {
        builder.HasKey(e => e.FlashCardID);
        builder.Property(e => e.FlashCardID).HasColumnType("uniqueidentifier");
        builder.Property(e => e.FrontText).HasColumnType("nvarchar(100)");
        builder.Property(e => e.CreatedDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.BackText).HasColumnType("nvarchar(100)");

        builder.HasOne(e => e.Category)
            .WithMany(d => d.FlashCards)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(e => e.CategoryID)
            .HasConstraintName("FK_FlashCard_Category");

        builder.HasMany(s => s.Tags)
            .WithMany(c => c.FlashCards);


    }
}