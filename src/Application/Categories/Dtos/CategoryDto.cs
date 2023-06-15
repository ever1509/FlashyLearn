namespace Application.Categories.Dtos;

public class CategoryDto
{
    public Guid CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid UserID { get; set; }
}