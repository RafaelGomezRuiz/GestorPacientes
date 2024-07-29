using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Application.ViewModels.User;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class PatientController : Controller
    {
        protected readonly IPatientService _patientService;
        protected readonly ValidateUserSession _validateUserSession;
        public PatientController(IPatientService _patientService, ValidateUserSession validateUserSession)
        {
            this._patientService = _patientService;
            _validateUserSession = validateUserSession;

        }
        public async Task<IActionResult> Index()
        {
            List<PatientViewModel> patients = await _patientService.GetAllViewModelFromUser();
            return View(patients);
        }

        public IActionResult Create()
        {
            SavePatientViewModel savePatientViewModel = new();
            return View("SavePatient", savePatientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SavePatientViewModel savePatientViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePatient", savePatientViewModel);
            }
            SavePatientViewModel savePatientVm = await _patientService.Add(savePatientViewModel);
            if (savePatientVm != null || savePatientVm.Id != 0)
            {
                savePatientVm.Photo = UploadFile(savePatientViewModel.File, savePatientVm.Id);
                await _patientService.Update(savePatientVm, savePatientVm.Id);
            }
            return RedirectToRoute(new { controller = "Patient", action = "index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SavePatientViewModel savePatientViewModel = await _patientService.GetByIdSaveViewModel(id);
            return View("SavePatient", savePatientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SavePatientViewModel savePatientViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePatient", savePatientViewModel);
            }
            SavePatientViewModel savePatientDba = await _patientService.GetByIdSaveViewModel(savePatientViewModel.Id);
            savePatientViewModel.Photo = UploadFile(savePatientViewModel.File, savePatientDba.Id, true, savePatientDba.Photo);
            await _patientService.Update(savePatientViewModel, savePatientViewModel.Id);

            return RedirectToRoute(new { controller = "Patient", action = "index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            return View(await _patientService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }

            string basePath = $"/Images/Patients/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                { 
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }
                Directory.Delete(path);
            }
            await _patientService.Delete(id);
            return RedirectToRoute(new { controller = "Patient", action = "index" });
        }


        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode && file == null)
            {
                return imagePath;
            }
            string basePath = $"/Images/Patients/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split('/');
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);
                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }
    }
}
