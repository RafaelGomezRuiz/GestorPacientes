using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface ILaboratoryTestService : IGenericService<SaveLaboratoryTestViewModel,LaboratoryTestViewModel,LaboratoryTest>
    {
        Task<List<LaboratoryTestViewModel>> GetAllViewModelFromUser();
    }
}
