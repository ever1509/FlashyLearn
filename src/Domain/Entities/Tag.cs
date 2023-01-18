namespace Domain.Entities;

public sealed class Tag : BaseEntity
{
    private Tag(Guid tagId, string description) : base(tagId)
    {
        Description = description;
    }
    private Tag()
    {
        FlashCards = new HashSet<FlashCard>();
        FlashCardTags = new HashSet<FlashCardTag>();
    }
    public string Description { get; private set; } = string.Empty;

    public ICollection<FlashCard> FlashCards { get; private set; }
    public ICollection<FlashCardTag> FlashCardTags { get; private set; }

    public static Tag Create(Guid tagId, string description)
    {
        return new Tag(tagId, description);
    }
}