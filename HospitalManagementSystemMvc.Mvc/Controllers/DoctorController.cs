using HospitalManagementSystemMvc.Models.Doctor;
using HospitalManagementSystemMvc.Services.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemMvc.Mvc.Controllers;
public class   DoctorController : Controller
{
    private readonly IDoctorService _DoctorService;
    public DoctorController(IDoctorService DoctorService)
    {
        _DoctorService = DoctorService;
    }

    public async Task<IActionResult> Index()
    {
        List<DoctorIndexViewModel> doctors = await _DoctorService.GetAllDoctorsAsync();

        return View(doctors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DoctorCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is invalid.";
            return View(model);
        }

        if (await _DoctorService.CreateDoctorAsync(model) is false)
        {
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Doctor/details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var Doctor= await _DoctorService.GetDoctorByIdAsync((int)id);

        if (Doctor is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(Doctor);
    }

    // GET: Doctor/edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        var Doctor = await _DoctorService.GetDoctorByIdAsync((int)id);

        if (Doctor is null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(Doctor);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DoctorEditViewModel model)
    {
        var Doctor= await _DoctorService.EditDoctorByIdAsync(id, model);
        if (Doctor == false)
        {
            return NotFound();
        }

        if (Doctor != false)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }

    // GET: Doctor/delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _DoctorService.DeleteDoctorByIdAsync( id);

        if (entity == null)
        {
            TempData["ErrorMsg"] = $"Doctor #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}