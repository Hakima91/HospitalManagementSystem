using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystemMvc.Data.Entities;

public class DoctorEntity
{
    [Key]
    public int DoctorId{get;set;}
    public string? FirstName{get;set;}
    public string? LastName{get;set;}
    public string? Email{get;set;}
    public string? Address{get;set;}
}