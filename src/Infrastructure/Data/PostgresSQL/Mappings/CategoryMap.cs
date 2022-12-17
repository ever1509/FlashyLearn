using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.PostgresSQL.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryID);
            builder.Property(e => e.CategoryID).HasColumnType("uuid");
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.Property(e => e.Name).HasColumnType("text");
            builder.Property(e => e.UserID).IsRequired();
        }
    }
}
