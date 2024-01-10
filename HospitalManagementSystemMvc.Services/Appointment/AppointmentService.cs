using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Data.Entities;
using HospitalManagementSystemMvc.Models.Appointment;
using HospitalManagementSystemMvc.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemMvc.Services.Appointment;

public class AppointmentService : IAppointmentService
{
    private readonly HospitalManagementSystemDbContext _ctx;
    public AppointmentService(HospitalManagementSystemDbContext DbContext)
    {
        _ctx = DbContext;
    }

     
     public async Task<List<AppointmentIndexViewModel>> GetAllAppointmentAsync()
 {
    List<AppointmentIndexViewModel> Appointment= await _ctx.Appointments
    .Select(Appointment => new AppointmentIndexViewModel
    {
        Id = Appointment.AppointmentId,
        PatientId = Appointment.PatientId,
        DoctorId  = Appointment.PatientId,

    })
    .ToListAsync();
    

     return Appointment;
 }
    public async Task<bool> CreateAppointmentAsync(AppointmentCreateViewModel model)
    {
        AppointmentEntity entity = new()
        {
            // AppointmentId = model.Id,
            PatientId = model.PatientId,
            DoctorId = model.DoctorId,
            DateCreated = DateTime.Now
        };

        _ctx.Appointments.Add(entity);

        return await _ctx.SaveChangesAsync() == 1;
    }

    // GET: Appointment/details/{id}
    public async Task<AppointmentDetailViewModel> GetAppointmentByIdAsync(int id)
    {


        AppointmentEntity? entity = await _ctx.Appointments.FindAsync(id);
        if (entity is null)
            return null;



        AppointmentDetailViewModel model = new()
        {
            Id = entity.AppointmentId,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            DateCreated = DateTime.Now
        };

        await _ctx.SaveChangesAsync();
        return model;
    }

    // GET: Appointment/edit/{id}
    public async Task<AppointmentEditViewModel> GetEditAppointmentByIdAsync(int id)
    {
        var entity = await _ctx.Appointments.FindAsync(id);

        AppointmentEditViewModel model = new()
        {
            Id = entity.AppointmentId,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            DateCreated = DateTime.Now
        };

        await _ctx.SaveChangesAsync();
        return model;
    }


    public async Task<bool> EditAppointmentByIdAsync(int id, AppointmentEditViewModel model)
    {
        var entity = _ctx.Appointments.Find(id);

        entity.AppointmentId = model.Id;
        entity.PatientId = model.PatientId;
        entity.DoctorId = model.DoctorId;
        entity.DateCreated = DateTime.Now;

        _ctx.Entry(entity).State = EntityState.Modified;

        return await _ctx.SaveChangesAsync() == 1;
    }

    // GET: Appointment/delete/{id}

    public async Task<TextResponse> DeleteAppointmentByIdAsync(int id)
    {
        var AppointmentToDelete = await _ctx.Appointments.FirstOrDefaultAsync(e => e.AppointmentId == id);

        if (AppointmentToDelete != null)
        {
            _ctx.Appointments.Remove(AppointmentToDelete);
            await _ctx.SaveChangesAsync();
        }

        TextResponse response = new("Appointment successfully deleted");

        return response;
    }

    
}

