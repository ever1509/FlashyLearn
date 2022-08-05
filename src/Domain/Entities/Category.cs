namespace Domain.Entities;

public class Category
{
    public Category()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public Guid CategoryID { get; set; }
    public string Description { get; set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; }
}