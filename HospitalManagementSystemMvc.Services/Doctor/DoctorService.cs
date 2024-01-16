using System.Data.Common;
using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Data.Entities;
using HospitalManagementSystemMvc.Models.Doctor;
using HospitalManagementSystemMvc.Models.Response;
using HospitalManagementSystemMvc.Services.Doctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HospitalManagementSystemMvc.Service.Doctor;

public class DoctorService : IDoctorService
{
    private readonly HospitalManagementSystemDbContext _cxt;
    public DoctorService(HospitalManagementSystemDbContext dbContext)
    {
        _cxt =dbContext;
    }
    
    // Read all
 public async Task<List<DoctorIndexViewModel>> GetAllDoctorsAsync()
 {
    List<DoctorIndexViewModel> doctors = await _cxt.Doctors
    .Select(doctor => new DoctorIndexViewModel
    {
        FirstName = doctor.FirstName,
        LastName = doctor.LastName,
        Email  = doctor.Email,

    })
    .ToListAsync();
    

     return doctors;
 }
 
    // Create
 public async Task<bool> CreateDoctorAsync(DoctorCreateViewModel model)
 {
    DoctorEntity entity = new()
    {
    
        FirstName = model.FirstName,
        LastName = model.LastName,
        Email = model.Email,
        Address = model.Address
    };

    _cxt.Doctors.Add(entity);

    return await _cxt.SaveChangesAsync()==1;
 }

   // Read By id
  public async Task<DoctorDetailViewModel> GetDoctorByIdAsync(int  doctorId)

  {
    
        DoctorEntity? entity = await _cxt.Doctors.FindAsync(doctorId);
        if (entity is null)
            return null;


      
      DoctorDetailViewModel model = new()
        {
            FirstName = entity.LastName,
            Email = entity.Email,
            Address = entity.Address
        };

        await _cxt.SaveChangesAsync();
        return  model;
    }

      // Edit
     public async Task<bool> EditDoctorByIdAsync(int id, DoctorEditViewModel model)
    {
        var entity = _cxt.Doctors.Find(id);

        entity.FirstName = model.FirstName;
        entity.LastName = model.LastName;
        entity.Address = model.Address;
        entity.Email = model.Email;
        
        _cxt.Entry(entity).State = EntityState.Modified;

        return await _cxt.SaveChangesAsync() == 1;
    }
    
       //delete
         public  async Task<TextResponse> DeleteDoctorByIdAsync(int id)
    {
        var doctorToDelete = await  _cxt.Users.FirstOrDefaultAsync(e => e.Id == id);

        if (doctorToDelete != null)
        {
            _cxt.Users.Remove(doctorToDelete);
            await _cxt.SaveChangesAsync();
        }

        TextResponse response = new("Doctor successfully deleted");

        return response;
    }
  }

  

   


   