using Microsoft.AspNetCore.Mvc;

namespace WebApp.GestorPacientes.Controllers
{
    public class ConsultingRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
