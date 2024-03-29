namespace HospitalManagementSystemMvc.Models.Patient;

public class PatientIndexViewModel
{
    public int Id{get;set;}
    public String? FirstName{get;set;}
    public String? LastName{get;set;}
    public String? Email{get;set;}
    public DateTime DateOfBirth{get;set;}
}