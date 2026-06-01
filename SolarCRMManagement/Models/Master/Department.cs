using System.ComponentModel.DataAnnotations;

namespace SolarCRMManagement.Models.Master;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(20)]
    public string DepartmentCode { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string DepartmentName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
public enum DepartmentName
{
    Managing_Director = 1,
    General_Manager =2,
    State_Head = 3,
    Branch_Manager = 4,
    Relationship_Manager =5,
    Sales_Executive = 6,
    Procurement_Executive = 7,
    Warehouse_Manager = 8,
    Installation_Engineer = 9,
    Installation_Technician = 10,
    Documentation_Executive = 11,
    Service_Engineer = 12,
    Accountant = 13,
    HR_Executive = 14
}