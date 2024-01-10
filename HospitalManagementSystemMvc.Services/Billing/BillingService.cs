// using HospitalManagementSystemMvc.Data;
// using HospitalManagementSystemMvc.Data.Entities;
// using HospitalManagementSystemMvc.Models.Billing;
// using HospitalManagementSystemMvc.Services.Billing;

// namespace GeneralStoreMVC.Services.Billing;
// public class BillingService : IBillingService
// {
//     private readonly HospitalManagementSystemDbContext _ctx;

//     public BillingService( HospitalManagementSystemDbContext dbContext)
//     {
//         _ctx = dbContext;
//     }

//     public async Task<bool> CreateBillingAsync(int BilligId, BillingCreateVM model)
//     {
//         BillingEntity entity = new()
//         {
//             BilligId = model.billingId,
//             PatientId= model.patientId,
//             Amount = model.Amount,
//             DateOfBilling= DateTime.Now
//         };

//         _ctx.Billings.Add(entity);
        
//         return await _ctx.SaveChangesAsync() == 1;
//     }

   
// }

   