using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class District
{
    [Key]
    public int DistrictId { get; set; }

    [Required]
    public int StateId { get; set; }

    [Required]
    [StringLength(10)]
    public string DistrictCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string DistrictName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(StateId))]
    public virtual State? State { get; set; }
}