using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.User;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class LaboratoryTestController : Controller
    {
        protected readonly ILaboratoryTestService _laboratoryTestService;
        protected readonly ValidateUserSession _validateUserSession;
        public LaboratoryTestController(ILaboratoryTestService _laboratoryTestService, ValidateUserSession _validateUserSession)
        {
            this._laboratoryTestService = _laboratoryTestService;
            this._validateUserSession = _validateUserSession;

        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            var list = await _laboratoryTestService.GetAllViewModelFromUser();
            return View( list);
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            SaveLaboratoryTestViewModel saveLaboratoryTestViewModel = new();
            return View("SaveLaboratoryTest", saveLaboratoryTestViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveLaboratoryTestViewModel saveLaboratoryTestViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveLaboratoryTest", saveLaboratoryTestViewModel);
            }
            await _laboratoryTestService.Add(saveLaboratoryTestViewModel);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveLaboratoryTestViewModel saveLaboratoryTestViewModel = await _laboratoryTestService.GetByIdSaveViewModel(id);
            return View("SaveLaboratoryTest", saveLaboratoryTestViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SaveLaboratoryTestViewModel laboratoryTestViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveLaboratoryTest", laboratoryTestViewModel);
            }
            SaveLaboratoryTestViewModel saveLaboratoryTestVm = await _laboratoryTestService.GetByIdSaveViewModel(laboratoryTestViewModel.Id);
            
            await _laboratoryTestService.Update(laboratoryTestViewModel, saveLaboratoryTestVm.Id);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            return View(await _laboratoryTestService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            await _laboratoryTestService.Delete(id);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "index" });
        }
    }
}
