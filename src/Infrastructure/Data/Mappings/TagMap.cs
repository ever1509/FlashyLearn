using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(e => e.TagId);
            builder.Property(e => e.TagId).HasColumnType("uuid");
            builder.Property(e => e.Description).HasColumnType("text");
            
        }
    }
}
