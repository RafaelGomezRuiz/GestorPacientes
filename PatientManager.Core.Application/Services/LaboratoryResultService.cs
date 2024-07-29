using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Services
{
    public class LaboratoryResultService : GenericService<SaveLaboratoryResultViewModel, LaboratoryResultViewModel, LaboratoryResult>, ILaboratoryResultService
    {
        protected readonly ILaboratoryResultRepository _laboratoryResultRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAssessor;

        protected readonly UserViewModel userViewModel;

        public LaboratoryResultService(ILaboratoryResultRepository _laboratoryResultRepository, IHttpContextAccessor _httpContextAssessor, IMapper _mapper) : base(_laboratoryResultRepository, _mapper)
        {
            this._laboratoryResultRepository = _laboratoryResultRepository;
            this._mapper = _mapper;
            this._httpContextAssessor = _httpContextAssessor;

            userViewModel = _httpContextAssessor.HttpContext.Session.Get<UserViewModel>("user");

        }

        public async Task<List<LaboratoryResultViewModel>> GetAllViewModelWithInclude()
        {
            var list = await _laboratoryResultRepository.GetAllWithIncludeAsync(new List<string> { "LaboratoryTest", "Appointment.Patient" });
            return list
                .Where(labResult => labResult.Appointment.ConsultingRoomId == userViewModel.ConsultingRoomId
                && labResult.Status == false)
                .Select(s => new LaboratoryResultViewModel
                {
                    Descripcion = s.Descripcion,
                    Id = s.Id,
                    Status = s.Status,
                    LaboratoryTestId = s.LaboratoryTestId,
                    AppointmentId = s.AppointmentId,
                    PatientName = s.Appointment.Patient.Name + " " + s.Appointment.Patient.LastName,
                    IdCard = s.Appointment.Patient.IdCard,
                    TestName = s.LaboratoryTest.Name
                }).ToList();
        }
        public async Task<List<LaboratoryResultViewModel>> GetAllViewModelWithFromPatient(int patientId)
        {
            var list = await _laboratoryResultRepository.GetAllWithIncludeAsync(new List<string> { "LaboratoryTest", "Appointment.Patient" });
            return list
                .Where(labResult => labResult.Appointment.ConsultingRoomId == userViewModel.ConsultingRoomId
                && labResult.Appointment.PatientId==patientId)
                .Select(s => new LaboratoryResultViewModel
                {
                    Descripcion = s.Descripcion,
                    Id = s.Id,
                    Status = s.Status,
                    LaboratoryTestId = s.LaboratoryTestId,
                    AppointmentId = s.AppointmentId,
                    PatientName = s.Appointment.Patient.Name + " " + s.Appointment.Patient.LastName,
                    IdCard = s.Appointment.Patient.IdCard,
                    TestName = s.LaboratoryTest.Name
                }).ToList();
        }
    }
}
