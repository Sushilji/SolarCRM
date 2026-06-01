using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class Warehouse
{
    [Key]
    public int WarehouseId { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    [StringLength(20)]
    public string WarehouseCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string WarehouseName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? WarehouseManager { get; set; }

    [StringLength(15)]
    public string? MobileNo { get; set; }

    [StringLength(150)]
    public string? EmailId { get; set; }

    [StringLength(50)]
    public string? Capacity { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }
}