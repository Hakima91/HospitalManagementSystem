using HospitalManagementSystemMvc.Models.Appointment;
using HospitalManagementSystemMvc.Models.Response;

namespace HospitalManagementSystemMvc.Services.Appointment;
public interface IAppointmentService
{
    // Create
    Task<bool> CreateAppointmentAsync(AppointmentCreateViewModel model);

    // Read
    Task<List<AppointmentIndexViewModel>> GetAllAppointmentAsync();
    Task<AppointmentDetailViewModel> GetAppointmentByIdAsync(int id);
    Task<AppointmentEditViewModel> GetEditAppointmentByIdAsync(int id);

    // Edit
    Task<bool> EditAppointmentByIdAsync(int id, AppointmentEditViewModel model);

    // Delete
    Task<TextResponse> DeleteAppointmentByIdAsync(int id);
}