using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class LaboratoryResultController : Controller
    {
        protected readonly ILaboratoryResultService _laboratoryResultService;
        protected readonly ValidateUserSession _validateUserSession;
        public LaboratoryResultController(ILaboratoryResultService _laboratoryResultService, ValidateUserSession _validateUserSession)
        {
            this._laboratoryResultService = _laboratoryResultService;
            this._validateUserSession = _validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            List<LaboratoryResultViewModel> labResult = await _laboratoryResultService.GetAllViewModelWithInclude();
            return View(labResult);
        }
        public async Task<IActionResult> ReportResult(int id)
        {
            SaveReportLaboratoryResultViewModel SaveLabResultVm = new SaveReportLaboratoryResultViewModel();
            SaveLabResultVm.Id = id;
            return View(SaveLabResultVm);
        }
        [HttpPost]
        public async Task<IActionResult> ReportResult(SaveReportLaboratoryResultViewModel SaveLabResultVm)
        {
            SaveLaboratoryResultViewModel saveLabResult = await _laboratoryResultService.GetByIdSaveViewModel(SaveLabResultVm.Id);

            saveLabResult.Descripcion = SaveLabResultVm.Descripcion;
            saveLabResult.Status = true;
            await _laboratoryResultService.Update(saveLabResult, saveLabResult.Id);

            return RedirectToRoute(new { controller = "LaboratoryResult", action = "Index" });
        }
        public async Task<IActionResult> VerEstadoCita(int patientId)
        {
            List<LaboratoryResultViewModel> labResultVm=await _laboratoryResultService.GetAllViewModelWithFromPatient(patientId);
            return View(labResultVm);
        }
            
    }
}
