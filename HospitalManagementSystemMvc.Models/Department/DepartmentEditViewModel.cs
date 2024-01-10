namespace HospitalManagementSystemMvc.Models.Department;

public class DepartmentEditViewModel
{
    public int DepartmentId{get;set;}
    public string Name{get;set;}=string.Empty;
    public string Email{get;set;}=string.Empty;
    public string Address {get;set;}=string.Empty;
}