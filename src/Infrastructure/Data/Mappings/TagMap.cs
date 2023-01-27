using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(e => e.TagID);
            builder.Property(e => e.TagID).HasColumnType("uuid");
            builder.Property(e => e.Description).HasColumnType("text");
            
        }
    }
}
