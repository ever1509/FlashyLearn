namespace Application.FlashCards.Dtos;

public class FlashCardDto
{
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
}