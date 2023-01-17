namespace Domain.Entities;

public class Tag
{
    public Tag()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public Guid TagID { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public ICollection<FlashCard> FlashCards { get; private set; }
    public ICollection<FlashCardTag> FlashCardTags { get; private set; }
}