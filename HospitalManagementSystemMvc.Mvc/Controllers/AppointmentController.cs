

using HospitalManagementSystemMvc.Models.Appointment;
using HospitalManagementSystemMvc.Services.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemMvc.Mvc.Controllers;
public class   AppointmentController : Controller
{
    private readonly IAppointmentService _AppointmentService;
    public AppointmentController(IAppointmentService AppointmentService)
    {
        _AppointmentService = AppointmentService;
    }

    public async Task<IActionResult> Index()
    {
        List<AppointmentIndexViewModel> Appointments = await _AppointmentService.GetAllAppointmentAsync();

        return View(Appointments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AppointmentCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is invalid.";
            return View(model);
        }

        if (await _AppointmentService.CreateAppointmentAsync(model) is false)
        {
            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Appointment/details/{id}
    public async Task<IActionResult> Details(int id)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        var Appointment= await _AppointmentService.GetAppointmentByIdAsync(  id);

        if (Appointment is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(Appointment);
    }

    // GET: Appointment/edit/{id}
    public async Task<IActionResult> Edit(int id)
    {
        if (id ==0)
        {
            return RedirectToAction(nameof(Index));
        }
        
        var Appointment = await _AppointmentService.GetAppointmentByIdAsync(id);

        if (Appointment is null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(Appointment);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AppointmentEditViewModel model)
    {
        var Appointment= await _AppointmentService.EditAppointmentByIdAsync(id, model);
        if (Appointment== false)
        {
            return NotFound();
        }

        if (Appointment!= false)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }

    // GET: Appointment/delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _AppointmentService.DeleteAppointmentByIdAsync( id);

        if (entity == null)
        {
            TempData["ErrorMsg"] = $"Doctor #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}