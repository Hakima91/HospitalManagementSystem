using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Data.Entities;
using HospitalManagementSystemMvc.Models.Billing;
using HospitalManagementSystemMvc.Models.Response;
using HospitalManagementSystemMvc.Services.Billing;
using Microsoft.EntityFrameworkCore;

public class BillingService : IBillingService
{
    private readonly HospitalManagementSystemDbContext _ctx;
    public BillingService(HospitalManagementSystemDbContext DbContext)
    {
        _ctx = DbContext;
    }
        
        // Read All
       public async Task<List<BillingIndexViewModel>> GetAllBillingAsync()
 {
    List<BillingIndexViewModel> Billings= await _ctx.Billings
    .Select(Billing=> new BillingIndexViewModel
    {
        BillingId = Billing.BillingId,
        PatientId= Billing.PatientId,
        Amount = Billing.Amount,
        DateOfBilling = DateTime.Now

    })
    .ToListAsync();
    
     return Billings;
 }

    // Create

   public async Task<bool> CreateBillingAsync(BillingCreateViewModel model)
    {
        BillingEntity entity = new()
        {
        
            PatientId = model.PatientId,
            Amount= model.Amount,
            DateOfBilling = DateTime.Now
             
        };

        _ctx.Billings.Add(entity);

        return await _ctx.SaveChangesAsync() == 1;
    }

        //  read by id
       public async Task<BillingDetailViewModel> GetBillingByIdAsync(int id)
    {
        BillingEntity? entity = await _ctx.Billings.FindAsync(id);
        if (entity is null)
            return null;

        BillingDetailViewModel model = new()
        {
            BillingId = entity.BillingId,
            PatientId = entity.PatientId,
            Amount = entity.Amount,
            DateOfBilling = DateTime.Now
        };

        await _ctx.SaveChangesAsync();
        return model;
    }
    
    // Edit
public async Task<bool> EditBillingByIdAsync(int id, BillingEditViewModel model)
    {
        var entity = _ctx.Billings.Find(id);

        entity.BillingId = model.BillingId;
        entity.PatientId= model.PatientId;
        entity.Amount = model.Amount;

        _ctx.Entry(entity).State = EntityState.Modified;

        return await _ctx.SaveChangesAsync() == 1;
    }

    // Delete
     public async Task<TextResponse> DeleteBillingByIdAsync(int id)
    {
        var BillingToDelete = await _ctx.Billings.FirstOrDefaultAsync(e => e.BillingId == id);

        if (BillingToDelete != null)
        {
            _ctx.Billings.Remove(BillingToDelete);
            await _ctx.SaveChangesAsync();
        }

        TextResponse response = new("Billing successfully deleted");

        return response;
    }

   
}