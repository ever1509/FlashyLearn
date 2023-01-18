using Domain.Enums;

namespace Domain.Entities;

public sealed class FlashCard : BaseEntity
{
    private FlashCard(Guid flashCardId, string frontText, string backText, DateTime createdDate, Frequency frequency, Guid categoryId) : base(flashCardId)
    {
        FrontText = frontText;
        BackText = backText;
        CreatedDate = createdDate;
        Frequency = frequency;
        CategoryID = categoryId;
    }
    public FlashCard()
    {
        Tags = new HashSet<Tag>();
    }
    public string FrontText { get; private set; } = string.Empty;
    public string BackText { get; private set; } = string.Empty;
    public DateTime CreatedDate { get; private set; }
    public Frequency Frequency { get; private set; }
    public Guid CategoryID { get; private set; }
    public Category Category { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<FlashCardTag> FlashCardTags { get; set; }

    public static FlashCard Create(Guid flashCardId, string frontText, string backText, DateTime createdDate,
        Frequency frequency, Guid categoryId)
    {
        return new FlashCard(flashCardId, backText, frontText,
            DateTime.UtcNow, frequency, categoryId);
    }

    public void Update(string frontText, string backText, Guid categoryId, Frequency frequency)
    {
        FrontText = frontText;
        BackText = backText;
        CategoryID = categoryId;
        Frequency = frequency;
    }
}