namespace HospitalManagementSystemMvc.Models.Appointment;

public class AppointmentCreateViewModel
{
    public int PatientId{get ; set;}
    public int DoctorId{ get; set ;}
    public DateTime DateCreated { get; set;}
}