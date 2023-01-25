namespace Domain.Entities;

public sealed class Tag
{
    public Tag()
    {
        FlashCards = new HashSet<FlashCard>();
        FlashCardTags = new HashSet<FlashCardTag>();
    }
    private Tag(Guid tagId, string description)
    {
        TagId = tagId;
        Description = description;
    }

    public Guid TagId { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public ICollection<FlashCard> FlashCards { get; private set; }
    public ICollection<FlashCardTag> FlashCardTags { get; private set; }

    public static Tag Create(Guid tagId, string description)
    {
        return new Tag(tagId, description);
    }
}