using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemMvc.Data.Entities;

public class DoctorEntity
{
    [Key]
    public int DoctorId{get;set;}
    [Required,MaxLength(50)]
    public string? FirstName{get;set;}
    [Required,MaxLength(50)]
    public string? LastName{get;set;}
    [MaxLength(50)]
    public string? Email{get;set;}
    [MaxLength(100)]
    public string? Address{get;set;}
}