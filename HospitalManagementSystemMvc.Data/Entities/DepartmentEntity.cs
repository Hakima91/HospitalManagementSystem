using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemMvc.Data.Entities;

public class DepartmentEntity
{
    [Key]
    public int DepartmentId{get;set;}
    public string Name{get;set;}=string.Empty;
    public string Email{get;set;}=string.Empty;
    public string Address {get;set;}=string.Empty;
    
}