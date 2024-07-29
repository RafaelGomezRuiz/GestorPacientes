using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Services
{
    public class AppointmentService : GenericService<SaveAppointmentViewModel,AppointmentViewModel,Appointment>,IAppointmentService
    {
        protected readonly IAppointmentRepository _appointmentRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _contextAccessor;
        UserViewModel userLogged;


        public AppointmentService(IAppointmentRepository _appointmentRepository, IMapper _mapper, IHttpContextAccessor _contextAccessor) :base(_appointmentRepository, _mapper )
        {
            this._appointmentRepository = _appointmentRepository;
            this._mapper = _mapper;
            this._contextAccessor= _contextAccessor;
            userLogged = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModelWithInclude()
        {
            IEnumerable<Appointment> appointmentsList= await _appointmentRepository.GetAllWithIncludeAsync(new List<string>{ "Doctor", "ConsultingRoom", "Patient" });

            return appointmentsList.Select(appointment => new AppointmentViewModel
            {
                Id= appointment.Id,
                DateAppointment= appointment.DateAppointment,
                TimeAppointment= appointment.TimeAppointment,
                Description= appointment.Description,
                Status= appointment.Status,
                DoctorId= appointment.DoctorId,
                ConsultingRoomId= appointment.ConsultingRoomId,
                PatientId= appointment.PatientId,
                PatientName=appointment.Patient.Name,
                DoctorName=appointment.Doctor.Name,

            }).Where(appointment=>appointment.ConsultingRoomId==userLogged.ConsultingRoomId).ToList();
        }
        

    }
}
