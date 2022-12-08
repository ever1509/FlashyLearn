using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class CategoryMap: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.CategoryID);
        builder.Property(e => e.CategoryID).HasColumnType("uniqueidentifier");
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Name).HasColumnType("nvarchar(25)");
        builder.Property(e => e.UserID).IsRequired();
    }
}