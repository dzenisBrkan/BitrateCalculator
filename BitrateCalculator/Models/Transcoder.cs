using System.ComponentModel.DataAnnotations;

namespace BitrateCalculator.Models;

public class Transcoder
{
    [Key]
    public int Id { get; set; }
    public string Device { get; set; }
    public string Model { get; set; }
    public List<NIC> NIC { get; set; }
}