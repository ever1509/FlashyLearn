namespace Domain.Entities;

public class Category
{
    private Category()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Guid UserID { get; private set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; }
    
    public static Category Create(Guid id, string name, Guid userId)
    {
        return new Category {Id = id, Name = name, UserID = userId};
    }
}