using System.ComponentModel.DataAnnotations;

namespace SolarCRMManagement.Models.Master;

public class State
{
    [Key]
    public int StateId { get; set; }

    [Required]
    [StringLength(10)]
    public string StateCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string StateName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? StateHead { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }
}
