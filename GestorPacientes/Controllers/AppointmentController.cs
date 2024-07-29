using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class AppointmentController : Controller
    {
        protected readonly IAppointmentService _appointmentService;
        protected readonly IPatientService _patientService;
        protected readonly IDoctorService _doctorService;
        protected readonly ILaboratoryTestService _laboratoryTestService;
        protected readonly ILaboratoryResultService _laboratoryResultService;

        protected readonly ValidateUserSession _validateUserSession;
        public AppointmentController(IAppointmentService _appointmentService, IHttpContextAccessor contextAccessor, ValidateUserSession _validateUserSession, IPatientService _patientService, IDoctorService _doctorService, ILaboratoryTestService _laboratoryTestService, ILaboratoryResultService laboratoryResultService)
        {
            this._appointmentService = _appointmentService;
            this._validateUserSession = _validateUserSession;
            this._doctorService = _doctorService;
            this._patientService = _patientService;
            this._laboratoryTestService = _laboratoryTestService;
            _laboratoryResultService = laboratoryResultService;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            IEnumerable<AppointmentViewModel> appointmentList = await _appointmentService.GetAllViewModelWithInclude();
            return View(appointmentList);
        }

        public async Task<IActionResult> Create()
        {
            SaveAppointmentViewModel saveAppointmentViewModel = new();
            saveAppointmentViewModel.Patients = await _patientService.GetAllViewModelFromUser();
            saveAppointmentViewModel.Doctors = await _doctorService.GetAllViewModelFromUser();
            return View("SaveAppointment", saveAppointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveAppointmentViewModel saveAppointmentViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                saveAppointmentViewModel.Patients = await _patientService.GetAllViewModelFromUser();
                saveAppointmentViewModel.Doctors = await _doctorService.GetAllViewModelFromUser();
                return View("SaveAppointment", saveAppointmentViewModel);
            }
            await _appointmentService.Add(saveAppointmentViewModel);

            return RedirectToRoute(new { controller = "Appointment", action = "index" });
        }

        public async Task<IActionResult> Consultar(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            SaveConsultAppointmentViewModel consultAppointmentViewModel = new();
            consultAppointmentViewModel.Id = id;
            consultAppointmentViewModel.LaboratoryTests = await _laboratoryTestService.GetAllViewModelFromUser();
            return View(consultAppointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consultar(SaveConsultAppointmentViewModel consultAppointmentViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                consultAppointmentViewModel.LaboratoryTests = await _laboratoryTestService.GetAllViewModelFromUser();
                return View("Consultar", consultAppointmentViewModel);
            }
            SaveAppointmentViewModel saveAppointmentViewModel = await _appointmentService.GetByIdSaveViewModel(consultAppointmentViewModel.Id);
            saveAppointmentViewModel.LaboratoryTestIds = consultAppointmentViewModel.LaboratoryTestIds;
            SaveLaboratoryResultViewModel saveLaboratoryResultViewModel = new();
            foreach (var laboratoryTest in saveAppointmentViewModel.LaboratoryTestIds)
            {
                saveLaboratoryResultViewModel.AppointmentId = saveAppointmentViewModel.Id;
                saveLaboratoryResultViewModel.LaboratoryTestId = laboratoryTest;
                saveLaboratoryResultViewModel.Status = false;
                await _laboratoryResultService.Add(saveLaboratoryResultViewModel);
            }
            saveAppointmentViewModel.Status = "PenditenteResultados";
            await _appointmentService.Update(saveAppointmentViewModel, saveAppointmentViewModel.Id);
            return RedirectToRoute(new { controller = "Appointment", action = "Index" });
        }
        public async Task<IActionResult> Completar(int appointmentId)
        {
            SaveAppointmentViewModel appointmentVm=await _appointmentService.GetByIdSaveViewModel(appointmentId);
            appointmentVm.Status = "Completada";
            await _appointmentService.Update(appointmentVm, appointmentVm.Id);
            return RedirectToRoute(new {controller="Appointment",action="Index"});
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            return View(await _appointmentService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            await _appointmentService.Delete(id);
            return RedirectToRoute(new { controller = "Appointment", action = "index" });
        }
    }
}
