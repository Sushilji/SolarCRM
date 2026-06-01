using System.ComponentModel.DataAnnotations;

namespace SolarCRMManagement.Models.Master;

public class ItemMaster
{
    [Key]
    public int ItemId { get; set; }

    [Required]
    [StringLength(30)]
    public string ItemCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string ItemName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ItemCategory { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Unit { get; set; }

    [StringLength(50)]
    public string? HSNCode { get; set; }

    public decimal GSTPercentage { get; set; }

    [StringLength(100)]
    public string? Brand { get; set; }

    [StringLength(100)]
    public string? Make { get; set; }

    [StringLength(100)]
    public string? ModelNo { get; set; }

    [StringLength(100)]
    public string? Warranty { get; set; }

    public decimal ReorderLevel { get; set; }

    public bool IsStockItem { get; set; } = true;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }
}