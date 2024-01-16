using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Data.Entities;
using HospitalManagementSystemMvc.Models.Patient;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemMvc.Services.Patient;
     public class PatientService : IPatientService
{
    private readonly HospitalManagementSystemDbContext _ctx;
    public PatientService(HospitalManagementSystemDbContext dbContext)
    {
        _ctx = dbContext;
    }
     //read All
    public async Task<List<PatientIndexViewModel>> GetAllPatientsAsync()
    {
        List<PatientIndexViewModel> patient= await _ctx.Patients
            .Select(Patient=> new PatientIndexViewModel
            {
                Id = Patient.Id,
                FirstName = Patient.FirstName,
                LastName=Patient.LastName,
                Email = Patient.Email
            })
            .ToListAsync();

        return patient;
    }
     
     //Create
    public async Task<bool> CreatePatientAsync(PatientCreateViewModel model)
    {
        PatientEntity entity = new()
        {
            
            FirstName = model.FirstName,
            LastName=model.LastName,
            Email = model.Email,
            DateOfBirth=model.DateOfBirth
        };

        _ctx.Patients.Add(entity);

        return await _ctx.SaveChangesAsync() == 1;
    }

    // Read by Id
    public async Task<PatientDetailViewModel> GetPatientByIdAsync(int? id)
    {
        var entity = await _ctx.Patients
        
            .FirstOrDefaultAsync(c => c.Id == id);

        if (entity is null)
            return null;

        PatientDetailViewModel model = new()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName=entity.LastName,
            Email = entity.Email,
            
        };

        await _ctx.SaveChangesAsync();
        return  model;
    }

    public async Task<PatientEditViewModel> GetEditPatientByIdAsync(int? id)
    {
        var entity = await _ctx.Patients.FindAsync(id);

        PatientEditViewModel model = new()
        {
            Id=entity.Id,
            FirstName = entity.FirstName,
            LastName=entity.LastName,
            Email = entity.Email
        };

        await _ctx.SaveChangesAsync();
        return  model;
    }

     //Edit
    public async Task<bool> EditPatientByIdAsync(int id, PatientEditViewModel model)
    {
        var entity = _ctx.Patients.Find(id);

         entity.FirstName= model.FirstName;
         entity.LastName= model.LastName;
         entity.Email=model.Email;

        
        _ctx.Entry(entity).State = EntityState.Modified;

        return await _ctx.SaveChangesAsync() == 1;
    }

    

    // /delete
    public async Task<bool> DeletePatientAsync(int id)
    {
        var entity = await _ctx.Patients

            .FirstOrDefaultAsync(c => c.Id == id);

        if (entity is null)
        {
            return false;
        }
        return true;
   
      

    }

}

