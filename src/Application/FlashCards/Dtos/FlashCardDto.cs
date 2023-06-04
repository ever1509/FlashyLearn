using Domain.Enums;

namespace Application.FlashCards.Dtos;

public class FlashCardDto
{
    public Guid FlashCardID { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public Frequency Frequency { get; set; }
    public Guid CategoryID { get; set; } = Guid.Empty;
}