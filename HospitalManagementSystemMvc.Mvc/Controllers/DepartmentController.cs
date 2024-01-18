using System.ComponentModel.DataAnnotations;
using HospitalManagementSystemMvc.Models.Department;
using HospitalManagementSystemMvc.Services.Department;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemMvc.Mvc.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentService _DepartmentService;
    public DepartmentController(IDepartmentService DepartmentService)
    {
        _DepartmentService = DepartmentService;
    }
     public async Task<IActionResult> Index()
    {
        List<DepartmentIndexViewModel> Departments = await _DepartmentService.GetAllDepartmentAsync();

        return View(Departments);
    }

    public IActionResult Create()
    {
        return View();
    }

      [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DepartmentCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is invalid.";
            return View(model);
        }

        if (await _DepartmentService.CreateDepartmentAsync(model) is false)
        {
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        var Department= await _DepartmentService.GetDepartmentByIdAsync(  id);

        if (Department is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(Department);
    }

    // GET: Department/edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        
        var department = await _DepartmentService.GetDepartmentByIdAsync(id);

       DepartmentEditViewModel model = new()
        {
            DepartmentId = department.DepartmentId,
            Name = department.Name,
            Email = department.Email,
            Address = department.Address
        };
        if (department is null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // [HttpGet]
    // public IActionResult Edit()
    // {
    //     return View();
    // }

      [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DepartmentEditViewModel model)
    {
        var Department= await _DepartmentService.EditDepartmentByIdAsync(id, model);
        if (Department== false)
        {
            return NotFound();
        }

        if (Department!= false)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _DepartmentService.DeleteDepartmentByIdAsync( id);

        if (entity == null)
        {
            TempData["ErrorMsg"] = $"Doctor #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

}