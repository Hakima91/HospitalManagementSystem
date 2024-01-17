using HospitalManagementSystemMvc.Models.Department;
using HospitalManagementSystemMvc.Models.Response;

namespace HospitalManagementSystemMvc.Services.Department;

public interface IDepartmentService
{
    Task<bool> CreateDepartmentAsync(DepartmentCreateViewModel model);

    // Read
    Task<List<DepartmentIndexViewModel>> GetAllDepartmentAsync();
    
    Task<DepartmentDetailViewModel> GetDepartmentByIdAsync(int id);

    // Edit
    Task<bool> EditDepartmentByIdAsync(int id, DepartmentEditViewModel model);

    // Delete
    Task<TextResponse> DeleteDepartmentByIdAsync(int id);
}