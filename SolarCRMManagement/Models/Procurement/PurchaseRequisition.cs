using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolarCRMManagement.Models.Master;

namespace SolarCRMManagement.Models.Procurement;

public class PurchaseRequisition
{
    [Key]
    public int PRId { get; set; }

    [Required]
    [StringLength(30)]
    public string PRNo { get; set; } = string.Empty;

    public DateTime PRDate { get; set; } = DateTime.Now;

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int WarehouseId { get; set; }

    [Required]
    public int RequestedByEmployeeId { get; set; }

    [Required]
    [StringLength(500)]
    public string Purpose { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Remarks { get; set; }

    [StringLength(30)]
    public string Status { get; set; } = "Pending";

    public bool IsApproved { get; set; }

    public int? ApprovedByEmployeeId { get; set; }

    public DateTime? ApprovalDate { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public virtual Warehouse? Warehouse { get; set; }

    [ForeignKey(nameof(RequestedByEmployeeId))]
    public virtual Employee? RequestedBy { get; set; }
}