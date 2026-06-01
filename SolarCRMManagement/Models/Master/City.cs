using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class City
{
    [Key]
    public int CityId { get; set; }

    [Required]
    public int DistrictId { get; set; }

    [Required]
    [StringLength(20)]
    public string CityCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string CityName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(DistrictId))]
    public virtual District? District { get; set; }
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}