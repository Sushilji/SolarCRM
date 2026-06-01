using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class Branch
{
    [Key]
    public int BranchId { get; set; }

    [Required]
    public int CityId { get; set; }

    [Required]
    [StringLength(20)]
    public string BranchCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string BranchName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? ContactPerson { get; set; }

    [StringLength(15)]
    public string? MobileNo { get; set; }

    [StringLength(150)]
    public string? EmailId { get; set; }

    [StringLength(20)]
    public string? GSTNo { get; set; }

    [StringLength(100)]
    public string? BranchManager { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }

    [ForeignKey(nameof(CityId))]
    public virtual City? City { get; set; }

    //public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}