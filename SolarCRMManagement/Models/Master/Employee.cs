using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarCRMManagement.Models.Master;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [StringLength(20)]
    public string EmployeeCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string EmployeeName { get; set; } = string.Empty;

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    public int DesignationId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    public int BranchId { get; set; }

    public int? WarehouseId { get; set; }

    [Required]
    [StringLength(30)]
    public string EmployeeType { get; set; } = string.Empty;

    [StringLength(15)]
    public string? MobileNo { get; set; }

    [StringLength(150)]
    public string? EmailId { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? AadharNo { get; set; }

    [StringLength(20)]
    public string? PANNo { get; set; }

    public DateTime? JoiningDate { get; set; }

    public int? ReportingManagerId { get; set; }

    public decimal? Salary { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? ModifiedDate { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public virtual Department? Department { get; set; }

    [ForeignKey(nameof(DesignationId))]
    public virtual Designation? Designation { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role? Role { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch? Branch { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public virtual Warehouse? Warehouse { get; set; }
}