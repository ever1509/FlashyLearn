using Domain.Entities;

public class Tag
{
    public Tag()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public Guid TagID { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<FlashCard> FlashCards { get; set; }
}