namespace Application.FlashCards.Dtos;

public class FlashCardResponseDto
{
    public Guid FlashCardId { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
}