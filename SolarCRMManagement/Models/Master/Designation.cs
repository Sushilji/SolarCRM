using System.ComponentModel.DataAnnotations;

namespace SolarCRMManagement.Models.Master;

public class Designation
{
    [Key]
    public int DesignationId { get; set; }

    [Required]
    public string DesignationCode { get; set; } = string.Empty;

    [Required]
    public string DesignationName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

