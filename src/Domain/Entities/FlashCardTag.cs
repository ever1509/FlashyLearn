namespace Domain.Entities;

public class FlashCardTag
{
    public Guid FlashCardID { get; set; }
    public virtual FlashCard FlashCard { get; set; }
    public Guid TagID { get; set; }
    public virtual Tag Tag { get; set; }
}