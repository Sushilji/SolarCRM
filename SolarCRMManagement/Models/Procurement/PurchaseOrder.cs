using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolarCRMManagement.Models.Master;

namespace SolarCRMManagement.Models.Procurement;

public class PurchaseOrder
{
    [Key]
    public int POId { get; set; }

    [Required]
    [StringLength(30)]
    public string PONumber { get; set; } = string.Empty;

    public DateTime PODate { get; set; } = DateTime.Now;

    [Required]
    public int VendorId { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int WarehouseId { get; set; }

    public decimal TotalAmount { get; set; }

    [StringLength(1000)]
    public string? TermsAndConditions { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    public bool IsApproved { get; set; }

    public int? ApprovedByEmployeeId { get; set; }

    public DateTime? ApprovedDate { get; set; }

    [StringLength(30)]
    public string Status { get; set; } = "Pending";

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(VendorId))]
    public virtual Vendor? Vendor { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public virtual Warehouse? Warehouse { get; set; }
}