using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class Vendor
{
    [Key]
    public int VendorId { get; set; }

    [Required]
    [StringLength(20)]
    public string VendorCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string VendorName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? ContactPerson { get; set; }

    [StringLength(15)]
    public string? MobileNo { get; set; }

    [StringLength(150)]
    public string? EmailId { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? GSTNo { get; set; }

    [StringLength(20)]
    public string? PANNo { get; set; }

    [StringLength(100)]
    public string? StateName { get; set; }

    [StringLength(100)]
    public string? DistrictName { get; set; }

    [StringLength(100)]
    public string? CityName { get; set; }

    [StringLength(100)]
    public string? BankName { get; set; }

    [StringLength(50)]
    public string? AccountNo { get; set; }

    [StringLength(20)]
    public string? IFSCCode { get; set; }

    [StringLength(100)]
    public string? MaterialCategory { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }
}