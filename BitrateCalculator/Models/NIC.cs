using System.ComponentModel.DataAnnotations;

namespace BitrateCalculator.Models;

public class NIC
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public string MAC { get; set; }
    public DateTime Timestamp { get; set; }
    public string Rx { get; set; }
    public string Tx { get; set; }
}