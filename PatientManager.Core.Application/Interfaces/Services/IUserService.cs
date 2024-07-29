using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
        Task<UserViewModel> Login(LoginViewModel loginVm);
        Task<bool> UserNameExistsAsync(string userName);
        Task<List<UserViewModel>> GetAllViewModelFromUser();
    }
}
