using System.ComponentModel.DataAnnotations;

namespace ArkivGPT;

public class Summary
{
    public Summary(){}
    public Summary(int gnr, int bnr, int snr)
    {
        Gnr = gnr;
        Bnr = bnr;
        Snr = snr;
    }
    
    [Required]
    public int Gnr { get; set; }

    [Required]
    public int Bnr { get; set; }

    public int Snr { get; set; }
}