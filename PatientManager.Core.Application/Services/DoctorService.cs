using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class DoctorService : GenericService<SaveDoctorViewModel,DoctorViewModel,Doctor>,IDoctorService
    {
        protected readonly IDoctorRepository _doctorRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _contextAccessor;
        DoctorViewModel _doctorViewModel;

        public DoctorService(IDoctorRepository _doctorRepository, IMapper _mapper, IHttpContextAccessor _contextAccessor) :base(_doctorRepository,_mapper)
        {
            this._doctorRepository = _doctorRepository;
            this._mapper = _mapper;
            this._contextAccessor = _contextAccessor;
            _doctorViewModel = _contextAccessor.HttpContext.Session.Get<DoctorViewModel>("user");
        }

        public async Task<List<DoctorViewModel>> GetAllViewModelFromUser()
        {
            IEnumerable<Doctor> doctorViewModelList = await _doctorRepository.GetAllAsync();

            return _mapper.Map<List<DoctorViewModel>>(doctorViewModelList.Where(doctor => doctor.ConsultingRoomId == _doctorViewModel.ConsultingRoomId));
        }
    }
}
