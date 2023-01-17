namespace Domain.Entities;

public class FlashCardTag
{
    private FlashCardTag(Guid flashCardId, Guid tagId)
    {
        Id = flashCardId;
        TagID = tagId;
    }
    public Guid Id { get; private set; }
    public virtual FlashCard FlashCard { get; set; }
    public Guid TagID { get; private set; }
    public virtual Tag Tag { get; set; }

    public static FlashCardTag Create(Guid flashCardId, Guid tagId)
    {
        return new FlashCardTag(flashCardId, tagId);
    }
}