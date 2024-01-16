using HospitalManagementSystemMvc.Models.Patient;

namespace HospitalManagementSystemMvc.Services.Patient;
public interface IPatientService
{
    // Create
    Task<bool> CreatePatientAsync(PatientCreateViewModel model);

    // Read
    Task<List<PatientIndexViewModel>> GetAllPatientsAsync();
    Task<PatientDetailViewModel> GetPatientByIdAsync(int? id);
    Task<PatientEditViewModel> GetEditPatientByIdAsync(int? id);

    // Edit
    Task<bool> EditPatientByIdAsync(int id, PatientEditViewModel model);

    // Delete
    Task<bool> DeletePatientAsync(int id);
    
}
