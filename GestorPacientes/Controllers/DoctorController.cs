using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.User;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class DoctorController : Controller
    {
        protected readonly IDoctorService _doctorService;
        protected readonly ValidateUserSession _validateUserSession;
        public DoctorController(IDoctorService _doctorService, ValidateUserSession validateUserSession)
        {
            this._doctorService = _doctorService;
            _validateUserSession = validateUserSession;

        }
        public async Task<IActionResult> Index()
        {
            List<DoctorViewModel> doctors = await _doctorService.GetAllViewModelFromUser();
            return View(doctors);
        }

        public IActionResult Create()
        {
            SaveDoctorViewModel saveDoctorViewModel = new();
            return View("SaveDoctor", saveDoctorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveDoctorViewModel saveDoctorViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveDoctor", saveDoctorViewModel);
            }
            SaveDoctorViewModel saveDoctorVm = await _doctorService.Add(saveDoctorViewModel);
            if (saveDoctorVm != null || saveDoctorVm.Id != 0)
            {
                saveDoctorVm.Photo = UploadFile(saveDoctorViewModel.File, saveDoctorVm.Id);
                await _doctorService.Update(saveDoctorVm, saveDoctorVm.Id);
            }
            return RedirectToRoute(new { controller = "Doctor", action = "index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveDoctorViewModel saveDoctorViewModel = await _doctorService.GetByIdSaveViewModel(id);
            return View("SaveDoctor", saveDoctorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SaveDoctorViewModel saveDoctorViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveDoctor", saveDoctorViewModel);
            }
            SaveDoctorViewModel saveDoctorDba = await _doctorService.GetByIdSaveViewModel(saveDoctorViewModel.Id);
            saveDoctorViewModel.Photo = UploadFile(saveDoctorViewModel.File, saveDoctorDba.Id,true, saveDoctorDba.Photo);
            await _doctorService.Update(saveDoctorViewModel, saveDoctorViewModel.Id);
            
            return RedirectToRoute(new { controller = "Doctor", action = "index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            return View(await _doctorService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }

            string basePath = $"/Images/Doctors/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                //Para borrar los folder que tengan los archivos dentro
                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }
                //sizeof no hacemos lo anterior esto da error
                Directory.Delete(path);
            }
            await _doctorService.Delete(id);
            return RedirectToRoute(new { controller = "Doctor", action = "index" });
        }


        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode && file == null)
            {
                return imagePath;
            }
            string basePath = $"/Images/Doctors/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Guid guid = Guid.NewGuid(); //NombreUnico
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
