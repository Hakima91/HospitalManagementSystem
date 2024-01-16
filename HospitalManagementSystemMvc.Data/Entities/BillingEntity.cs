using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemMvc.Data.Entities;

public class BillingEntity
{
    [Key]
    public int BillingId{get;set;}
    
    [ForeignKey(nameof(PatientId))]
    public int PatientId{get;set;}
    [ MaxLength(100)]
    public int Amount {get;set;}
    public DateTime DateOfBilling{get;set;}
     
}