using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolarCRMManagement.Models.Master;

namespace SolarCRMManagement.Models.Procurement;

public class PurchaseRequisitionItem
{
    [Key]
    public int PRItemId { get; set; }

    [Required]
    public int PRId { get; set; }

    [Required]
    public int ItemId { get; set; }

    [Required]
    public decimal Quantity { get; set; }

    [StringLength(100)]
    public string? Unit { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    [ForeignKey(nameof(PRId))]
    public virtual PurchaseRequisition? PurchaseRequisition { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual ItemMaster? Item { get; set; }
}