using System.Dynamic;

namespace Domain.Entities;

public class Category
{
    private Category(Guid categoryId, string name, Guid userId)
    {
        CategoryID = categoryId;
        Name = name;
        UserID = userId;
    }
    private Category()
    {
        FlashCards = new HashSet<FlashCard>();
    }

    public Guid CategoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Guid UserID { get; private set; }

    public virtual ICollection<FlashCard> FlashCards { get; set; }

    public static Category Create(Guid categoryId, string name, Guid userId)
    {
        return new Category(categoryId, name, userId);
    }

    public void Update(string name, Guid userId)
    {
        Name = name;
        UserID = userId;
    }
}