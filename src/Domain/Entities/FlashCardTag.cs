namespace Domain.Entities;

public sealed class FlashCardTag : BaseEntity
{
    private FlashCardTag(Guid id, Guid tagId) : base(id)
    {
        TagID = tagId;
    }
    public FlashCard FlashCard { get; set; }
    public Guid TagID { get; private set; }
    public Tag Tag { get; set; }

    public static FlashCardTag Create(Guid flashCardId, Guid tagId)
    {
        return new FlashCardTag(flashCardId, tagId);
    }
}