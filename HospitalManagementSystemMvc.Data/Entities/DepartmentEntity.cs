using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemMvc.Data.Entities;

public class DepartmentEntity
{
    [Key]
    public int DepartmentId{get;set;}
    [MaxLength(100)]
    public string Name{get;set;}=string.Empty;
    [MaxLength(100)]
    public string Email{get;set;}=string.Empty;
    [MaxLength(100)]
    public string Address {get;set;}=string.Empty;
    
}