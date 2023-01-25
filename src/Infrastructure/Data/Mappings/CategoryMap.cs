using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uuid");
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Name).HasColumnType("text");
            builder.Property(e => e.UserId).IsRequired().HasColumnType("uuid");
        }
    }
}
