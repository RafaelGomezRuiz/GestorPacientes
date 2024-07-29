using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface ILaboratoryResultService : IGenericService<SaveLaboratoryResultViewModel, LaboratoryResultViewModel, LaboratoryResult>
    {
        Task<List<LaboratoryResultViewModel>> GetAllViewModelWithInclude();
        Task<List<LaboratoryResultViewModel>> GetAllViewModelWithFromPatient(int patientId);

    }
}
