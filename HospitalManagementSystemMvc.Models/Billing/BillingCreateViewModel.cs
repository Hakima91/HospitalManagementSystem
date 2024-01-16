namespace HospitalManagementSystemMvc.Models.Billing;

public class BillingCreateViewModel
{
    public int BillingId{get;set;}
    public int PatientId {get;set;}
    public int Amount{get;set;}
    public DateTime DateOfBilling{get;set;}
}