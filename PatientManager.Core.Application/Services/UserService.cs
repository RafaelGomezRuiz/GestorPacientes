using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel,UserViewModel,User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAssessor;
        protected readonly UserViewModel loggedUser;

        public UserService(IUserRepository _userRepository, IMapper _mapper, IHttpContextAccessor _httpContextAssessor) : base(_userRepository, _mapper)
        {
            this._userRepository = _userRepository;
            this._mapper = _mapper;
            this._httpContextAssessor = _httpContextAssessor;
            loggedUser=_httpContextAssessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<UserViewModel> Login(LoginViewModel loginVm)
        {
            User user = await _userRepository.LoginAsync(loginVm);
            if (user == null)
            {
                return null;
            }
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            IEnumerable<User> userList= await _userRepository.GetAllAsync();
            return userList.Any(user=>user.UserName==userName);
        }

        public async Task<List<UserViewModel>> GetAllViewModelFromUser()
        {
            IEnumerable<User> users= await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserViewModel>>(users.Where(user=>user.ConsultingRoomId==loggedUser.ConsultingRoomId));
        }
    }
}
