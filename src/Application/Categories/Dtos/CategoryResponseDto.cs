namespace Application.Categories.Dtos;

public class CategoryResponseDto
{
    public Guid CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? UserID { get; set; }
}