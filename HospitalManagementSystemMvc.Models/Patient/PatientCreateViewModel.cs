namespace HospitalManagementSystemMvc.Models.Patient;

public class PatientCreateViewModel
{
    public int Id{get;set;}
    public String FirstName{get;set;}= string.Empty;
    public String LastName{get;set;}=string.Empty;
    public String Email{get;set;}=string.Empty;
    public DateTime DateOfBirth{get;set;}
}