namespace Domain.Entities;

public class Frequency
{
    public Guid FrequencyID { get; set; }
    public TimeSpan Timeline { get; set; }

    public virtual FlashCard FlashCard { get; set; }
    
}