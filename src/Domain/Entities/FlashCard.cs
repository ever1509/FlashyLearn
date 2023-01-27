using Domain.Enums;

namespace Domain.Entities;

public class FlashCard
{
    public FlashCard(Guid flashCardId, string frontText, string backText, Frequency frequency, Guid categoryId)
    {
        FlashCardID = flashCardId;
        FrontText = frontText;
        BackText = backText;
        Frequency = frequency;
        CategoryID = categoryId;
        CreatedDate = DateTime.UtcNow;
    }
    private FlashCard()
    {
        Tags = new HashSet<Tag>();
    }

    public Guid FlashCardID { get; private set; }
    public string FrontText { get; private set; }
    public string BackText { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public Frequency Frequency { get; private set; }
    public Guid CategoryID { get; private set; }
    public virtual Category Category { get; set; }
    public ICollection<Tag> Tags { get; set; }

    public static FlashCard Create(Guid flashcardId, string frontText, string backText, Frequency frequency, Guid categoryId)
    {
        return new FlashCard(flashcardId, frontText, backText, frequency, categoryId);
    }

    public void Update(string frontText, string backText, Frequency frequency, Guid categoryId)
    {
        FrontText = frontText;
        BackText = backText;
        Frequency = frequency;
        CategoryID = categoryId;
    }
}