namespace Application.FlashCards.Dtos;

public class FlashCardResponseDto
{
    public Guid FlashCardID { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public Guid CategoryID { get; set; }

}