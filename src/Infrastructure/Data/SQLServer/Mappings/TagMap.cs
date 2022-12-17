using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.SQLServer.Mappings;

public class TagMap : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(e => e.TagID);
        builder.Property(e => e.TagID).HasColumnType("uniqueidentifier");
        builder.Property(e => e.Description).HasColumnType("nvarchar(200)");
    }
}