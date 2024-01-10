using HospitalManagementSystemMvc.Services.Patient;
using HospitalManagementSystemMvc.Models.Patient;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemMvc.Mvc.ControllersControllers;
public class PatientController : Controller
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<IActionResult> Index()
    {
        List<PatientIndexViewModel> patient = await _patientService.GetAllPatientsAsync();

        return View(patient);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PatientCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is invalid.";
            return View(model);
        }

        if (await _patientService.CreatePatientAsync(model) is false)
        {
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: patient/details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var patient = await _patientService.GetPatientByIdAsync(id);

        if (patient is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(patient);
    }

    // GET: patient/edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        var patient = await _patientService.GetEditPatientByIdAsync(id);

        if (patient is null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, PatientEditViewModel model)
    {
        var patient= await _patientService.EditPatientByIdAsync(id, model);
        if (patient == false)
        {
            return NotFound();
        }

        if (patient != false)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }

    // GET: patient/delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _patientService.DeletePatientAsync( id);

        if (entity == false)
        {
            TempData["ErrorMsg"] = $"Patient #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}