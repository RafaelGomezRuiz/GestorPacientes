using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.ViewModels.User;

namespace WebApp.GestorPacientes.Middlewares
{
    public class ValidateUserSession 
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        public bool HasUser()
        {
            UserViewModel? userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            
            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}
