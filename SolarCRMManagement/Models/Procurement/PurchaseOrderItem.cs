using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolarCRMManagement.Models.Master;

namespace SolarCRMManagement.Models.Procurement;

public class PurchaseOrderItem
{
    [Key]
    public int POItemId { get; set; }

    [Required]
    public int POId { get; set; }

    [Required]
    public int ItemId { get; set; }

    [Required]
    public decimal Quantity { get; set; }

    [Required]
    public decimal Rate { get; set; }

    public decimal GSTPercent { get; set; }

    public decimal Amount { get; set; }

    [ForeignKey(nameof(POId))]
    public virtual PurchaseOrder? PurchaseOrder { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual ItemMaster? Item { get; set; }
}