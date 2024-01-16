using HospitalManagementSystemMvc.Models.Billing;
using HospitalManagementSystemMvc.Models.Response;

namespace HospitalManagementSystemMvc.Services.Billing;

public interface IBillingService
{
    Task<bool> CreateBillingAsync(BillingCreateViewModel model);

    // Read
    Task<List<BillingIndexViewModel>> GetAllBillingAsync();
    Task<BillingDetailViewModel> GetBillingByIdAsync(int id);
    // Task<DepartmentEditViewModel> GetEditDepartmentByIdAsync(int id);

    // Edit
    Task<bool> EditBillingByIdAsync(int id, BillingEditViewModel model);

    // Delete
    Task<TextResponse> DeleteBillingByIdAsync(int id);
}