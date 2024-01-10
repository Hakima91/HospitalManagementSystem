using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalManagementSystemMvc.Data.Entities;

public class AppointmentEntity
{
    [Key]
    public int AppointmentId{ get; set;}
    
    public int PatientId{ get; set;}
    public int DoctorId {get;set;}
    public DateTime DateCreated { get; set; }
}     
