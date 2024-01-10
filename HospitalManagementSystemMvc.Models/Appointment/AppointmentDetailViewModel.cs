namespace HospitalManagementSystemMvc.Models.Appointment;

public class AppointmentDetailViewModel
{
    public int Id{ get; set; }
    public int PatientId{get ; set;}
    public int DoctorId{ get; set ;}
    public DateTime DateCreated { get; set;}
}