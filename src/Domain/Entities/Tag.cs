namespace Domain.Entities;

public class Tag
{
    private Tag(Guid tagId, string description)
    {
        Id = tagId;
        Description = description;
    }
    private Tag()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public Guid Id { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public ICollection<FlashCard> FlashCards { get; private set; }
    public ICollection<FlashCardTag> FlashCardTags { get; private set; }

    public static Tag Create(Guid tagId, string description)
    {
        return new Tag(tagId, description);
    }
}