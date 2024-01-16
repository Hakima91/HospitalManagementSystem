using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalManagementSystemMvc.Data.Entities;

public class AppointmentEntity
{
    [Key]
    public int AppointmentId{ get; set;}

    [ForeignKey(nameof(PatientId))]
    public int PatientId{ get; set;}
    
    [ForeignKey(nameof(DoctorId))]
    public int DoctorId {get;set;}
    public DateTime DateCreated { get; set; }
}     
