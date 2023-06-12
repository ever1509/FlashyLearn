namespace Domain.Entities;

public class Category
{
    public Guid CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? UserID { get; set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; } = null!;
}