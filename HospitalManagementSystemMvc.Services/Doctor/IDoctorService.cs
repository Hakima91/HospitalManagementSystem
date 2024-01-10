using HospitalManagementSystemMvc.Models.Doctor;
using HospitalManagementSystemMvc.Models.Response;

namespace HospitalManagementSystemMvc.Services.Doctor;

public interface IDoctorService
{
     // Create
    Task<bool> CreateDoctorAsync(DoctorCreateViewModel model);

    // Read
    Task<List<DoctorIndexViewModel>> GetAllDoctorsAsync();
    Task<DoctorDetailViewModel> GetDoctorByIdAsync(int id);
    // Task<DoctorEditViewModel> GetEditDoctorByIdAsync(int id);

    // Edit
    Task<bool> EditDoctorByIdAsync(int id, DoctorEditViewModel model);

    // Delete
    Task<TextResponse> DeleteDoctorByIdAsync(int id);
}

