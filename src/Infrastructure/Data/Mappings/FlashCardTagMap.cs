using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class FlashCardTagMap: IEntityTypeConfiguration<FlashCardTag>
{
    public void Configure(EntityTypeBuilder<FlashCardTag> builder)
    {
        
    }
}