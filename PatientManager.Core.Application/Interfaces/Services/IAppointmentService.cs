using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IAppointmentService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel, Appointment>
    {
        Task<List<AppointmentViewModel>> GetAllViewModelWithInclude();
    }
}
