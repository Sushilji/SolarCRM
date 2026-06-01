using System.ComponentModel.DataAnnotations;

namespace SolarCRMManagement.Models.Master;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [StringLength(20)]
    public string RoleCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string RoleName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }
}