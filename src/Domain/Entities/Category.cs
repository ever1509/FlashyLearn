namespace Domain.Entities;

public class Category
{
    public int CategoryID { get; set; }
    public string Description { get; set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; }
}