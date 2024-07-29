using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class PatientService : GenericService<SavePatientViewModel, PatientViewModel, Patient>, IPatientService
    {
        protected readonly IPatientRepository _patientRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly UserViewModel loggedUser;

        public PatientService(IPatientRepository _patientRepository, IMapper _mapper, IHttpContextAccessor _contextAccessor) :base(_patientRepository, _mapper)
        {
            this._patientRepository = _patientRepository;
            this._mapper = _mapper;
            this._contextAccessor = _contextAccessor;
            loggedUser = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<List<PatientViewModel>> GetAllViewModelFromUser()
        {
            IEnumerable<Patient> doctorViewModelList = await _patientRepository.GetAllAsync();

            return _mapper.Map<List<PatientViewModel>>(doctorViewModelList.Where(doctor => doctor.ConsultingRoomId == loggedUser.ConsultingRoomId));
        }
    }
}
