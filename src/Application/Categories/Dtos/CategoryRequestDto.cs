namespace Application.Categories.Dtos;

public class CategoryRequestDto
{
    public Guid? CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
}