using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystemMvc.Data.Entities;

public class PatientEntity: IdentityUser<int>
{
    [Key]
    public int PatientId{get;set;}

    [Display(Name = "First Name")]
    public string? FirstName{get;set;}

    [Display(Name = "Last Name")]
    public string? LastName{get;set;}

    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth{get;set;}
}