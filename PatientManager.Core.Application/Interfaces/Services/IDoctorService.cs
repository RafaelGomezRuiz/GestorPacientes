using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel, Doctor>
    {
        Task<List<DoctorViewModel>> GetAllViewModelFromUser();
    }
}
