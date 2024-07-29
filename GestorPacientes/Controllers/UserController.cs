using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Application.Helpers;

using PatientManager.Infraestructure.Persistence.Context;
using WebApp.GestorPacientes.Middlewares;

namespace WebApp.GestorPacientes.Controllers
{
    public class UserController : Controller
    {
        protected readonly IUserService _userService;
        protected readonly IConsultingRoomService _consultingRoomService;
        protected readonly ValidateUserSession _validateUserSession;

        public UserController(IUserService _userService, IConsultingRoomService _consultingRoomService, ValidateUserSession _validateUserSession)
        {
            this._userService=_userService;
            this._consultingRoomService=_consultingRoomService ;
            this._validateUserSession = _validateUserSession ;
        }
        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", user = "Index" });
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel loginVm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", user = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }
            UserViewModel userVm= await _userService.Login(loginVm);
            if (userVm!=null)
            {
                HttpContext.Session.Set<UserViewModel>("user",userVm);
                if (userVm.UserType == "assistant")
                {
                    return RedirectToRoute(new { controller = "Patient", action = "index" });
                }

                return RedirectToRoute(new { controller = "home", action = "index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Credenciales invalidas intentelo nuevamente");
            }
            return View(loginVm);
        }

        public IActionResult Register()
        {
            
            SaveUserViewModel saveUserViewModel = new();
            return View("SaveUser", saveUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(SaveUserViewModel userViewModel)
       {
            
            if (!ModelState.IsValid)
            {
                return View("SaveUser",userViewModel);
            }
            if (await _userService.UserNameExistsAsync(userViewModel.UserName))
            {
                ModelState.AddModelError("userValidation", "Username already exists");
                return View("SaveUser",userViewModel);
            }
            if (!_validateUserSession.HasUser())
            {
                SaveConsultingRoomViewModel saveConsultingRoomViewModel = new();
                saveConsultingRoomViewModel.Name = userViewModel.ConsultingRoomName;
                saveConsultingRoomViewModel = await _consultingRoomService.Add(saveConsultingRoomViewModel);
                userViewModel.ConsultingRoomId = saveConsultingRoomViewModel.Id;
            }
            await _userService.Add(userViewModel);
            return RedirectToRoute(new {controller = "user", action= "index"});
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveUserViewModel saveUserViewModel= await _userService.GetByIdSaveViewModel(id);
            return View("SaveUser", saveUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SaveUserViewModel userViewModel)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveUser", userViewModel);
            }
            SaveUserViewModel saveUserVm= await _userService.GetByIdSaveViewModel(userViewModel.Id);
            if(userViewModel.UserName!= saveUserVm.UserName) 
            {
                if (await _userService.UserNameExistsAsync(userViewModel.UserName))
                {
                    ModelState.AddModelError("userValidation", "Username already exists");
                    return View("SaveUser", userViewModel);
                }
            }
            if (userViewModel.Password==null)
            {
                SaveUserViewModel user= await _userService.GetByIdSaveViewModel(userViewModel.Id);
                userViewModel.Password= user.Password;
            }
            await _userService.Update(userViewModel,userViewModel.Id);
            return RedirectToRoute(new { controller = "Home", action = "index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            return View(await _userService.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", user = "Index" });
            }
            await _userService.Delete(id);
            return RedirectToRoute(new { controller = "Home", action = "index" });
        }

        public async Task<IActionResult> LogOut()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "user", action = "index" });
        }

    }
}
