using Domain.Enums;

namespace Domain.Entities;

public class FlashCard
{
    public Guid FlashCardID { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public Frequency Frequency { get; set; }
    public Guid CategoryID { get; set; }
    public virtual Category Category { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = null!;
}