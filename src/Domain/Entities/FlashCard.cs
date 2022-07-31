namespace Domain.Entities;

public class FlashCard
{
    public int FlashCardID { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public DateTime CreatedDate { get; set; }

    public int CategoryID { get; set; }
    public virtual Category Category { get; set; }

    public int FrequencyID { get; set; }
    public virtual Frequency Frequency { get; set; }
}