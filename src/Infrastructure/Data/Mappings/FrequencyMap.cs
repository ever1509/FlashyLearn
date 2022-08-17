using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class FrequencyMap: IEntityTypeConfiguration<Frequency>
{
    public void Configure(EntityTypeBuilder<Frequency> builder)
    {
        builder.HasKey(e => e.FrequencyID);
        builder.Property(e => e.FrequencyID).HasColumnType("uuid");
        builder.Property(e => e.Timeline).HasColumnType("time");
    }
}