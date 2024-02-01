using System.ComponentModel.DataAnnotations;

namespace ArkivGPT;

public class PropertyInfo
{
    public PropertyInfo(){}

    public PropertyInfo(int gnr, int bnr, int snr, string address)
    {
        Gnr = gnr;
        Bnr = bnr;
        Snr = snr;
        Address = address;
    }
    
    [Required]
    public int Gnr { get; set; }
    
    [Required]
    public int Bnr { get; set; }
    
    [Required]
    public int Snr { get; set; }
    
    [Required]
    public String Address { get; set; }
}