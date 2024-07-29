using GestorPacientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.User;
using System.Diagnostics;
using WebApp.GestorPacientes.Middlewares;

namespace GestorPacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ValidateUserSession _validateUserSession;
        protected readonly IUserService _userSerive;


        public HomeController(ILogger<HomeController> logger, ValidateUserSession _validateUserSession, IUserService _userSerive)
        {
            _logger = logger;
            this._validateUserSession = _validateUserSession;  
            this._userSerive = _userSerive;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            List<UserViewModel> users = await _userSerive.GetAllViewModelFromUser();

            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
