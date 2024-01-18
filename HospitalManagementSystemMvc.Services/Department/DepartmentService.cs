using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Data.Entities;
using HospitalManagementSystemMvc.Models.Department;
using HospitalManagementSystemMvc.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemMvc.Services.Department;

public class DepartmentService : IDepartmentService
{
    private readonly HospitalManagementSystemDbContext _ctx;
    public DepartmentService(HospitalManagementSystemDbContext DbContext)
    {
        _ctx = DbContext;
    }

    //read all
    public async Task<List<DepartmentIndexViewModel>> GetAllDepartmentAsync()
    {
        List<DepartmentIndexViewModel> Departments = await _ctx.Departments
        .Select(Department => new DepartmentIndexViewModel
        {
            Id = Department.DepartmentId,
            Name = Department.Name,
            Email = Department.Email,
            Address = Department.Address

        })
        .ToListAsync();

        return Departments;
    }
    // Create
    public async Task<bool> CreateDepartmentAsync(DepartmentCreateViewModel model)
    {
        DepartmentEntity entity = new()
        {
            // AppointmentId = model.Id,
            DepartmentId = model.DepartmentId,
            Name = model.Name,
            Email = model.Email,
            Address = model.Address
        };

        _ctx.Departments.Add(entity);

        return await _ctx.SaveChangesAsync() == 1;
    }

    // read by id
    public async Task<DepartmentDetailViewModel> GetDepartmentByIdAsync(int id)
    {
        DepartmentEntity? entity = await _ctx.Departments.FindAsync(id);
        if (entity is null)
            return null;

        DepartmentDetailViewModel model = new()
        {
            DepartmentId = entity.DepartmentId,
            Name = entity.Name,
            Email = entity.Email,
            Address = entity.Address,
        };

        await _ctx.SaveChangesAsync();
        return model;
    }

    // Edit
    public async Task<bool> EditDepartmentByIdAsync(int id, DepartmentEditViewModel model)
    {
        var entity = _ctx.Departments.Find(id);

        entity.Name = model.Name;
        entity.Email = model.Email;
        entity.Address = model.Address;

        _ctx.Entry(entity).State = EntityState.Modified;

        return await _ctx.SaveChangesAsync() == 1;
    }

    // Delete
    public async Task<TextResponse> DeleteDepartmentByIdAsync(int id)
    {
        var DepartmentToDelete = await _ctx.Departments.FirstOrDefaultAsync(e => e.DepartmentId == id);

        if (DepartmentToDelete != null)
        {
            _ctx.Departments.Remove(DepartmentToDelete);
            await _ctx.SaveChangesAsync();
        }

        TextResponse response = new("Department successfully deleted");

        return response;
    }


}

