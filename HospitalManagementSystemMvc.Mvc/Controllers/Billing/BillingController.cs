using HospitalManagementSystemMvc.Models.Billing;
using HospitalManagementSystemMvc.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemMvc.Mvc.Controllers;
public class BillingController : Controller
{
    private readonly IBillingService _BillingService;
    public BillingController(IBillingService BillingService)
    {
        _BillingService = BillingService;
    }

       public async Task<IActionResult> Index()
    {
        List<BillingIndexViewModel> Billings = await _BillingService.GetAllBillingAsync();

        return View(Billings);
    }

    public IActionResult Create()
    {
        return View();
    }
       [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BillingCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is invalid.";
            return View(model);
        }

        if (await _BillingService.CreateBillingAsync(model) is false)
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

        var Billing= await _BillingService.GetBillingByIdAsync(  id);

        if (Billing is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(Billing);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BillingEditViewModel model)
    {
        var Billing= await _BillingService.EditBillingByIdAsync(id, model);
        if (Billing== false)
        {
            return NotFound();
        }

        if (Billing!= false)
        {
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }
     public async Task<IActionResult> Delete(int id)
    {
        var entity = await _BillingService.DeleteBillingByIdAsync( id);

        if (entity == null)
        {
            TempData["ErrorMsg"] = $"Billing #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }


}