using System.ComponentModel.DataAnnotations;

namespace ArkivGPT;

public record class SummaryElement
{
    public SummaryElement(){}
    
    public SummaryElement(DateOnly date, String resolution, String document)
    {
        Date = date;
        Resolution = resolution;
        Document = document;
    }
    
    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public String Resolution { get; set; }
    
    [Required]
    public String Document { get; set; }
}