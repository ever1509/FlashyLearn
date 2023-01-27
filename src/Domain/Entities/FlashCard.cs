using Domain.Enums;

namespace Domain.Entities;

public class FlashCard
{
    public FlashCard()
    {
        Tags = new HashSet<Tag>();
    }

    public Guid FlashCardID { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public DateTime CreatedDate { get; set; }
    public Frequency Frequency { get; set; }
    public Guid CategoryID { get; set; }
    public virtual Category Category { get; set; }
    public ICollection<Tag> Tags { get; set; }
}