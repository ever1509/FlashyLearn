namespace Domain.Entities;

public sealed class Category : BaseEntity
{
    private Category(Guid id, string name, Guid userId) : base(id)
    {
        Name = name;
        UserID = userId;
    }
    private Category()
    {
        FlashCards = new HashSet<FlashCard>();
    }
    public string Name { get; private set; } = string.Empty;
    public Guid UserID { get; private set; }

    public ICollection<FlashCard> FlashCards { get; set; }
    
    public static Category Create(Guid id, string name, Guid userId)
    {
        return new Category(id, name, userId);
    }

    public void Update(string name, Guid userId)
    {
        Name = name;
        UserID = userId;
    }
}