using AutoMapper;
using Microsoft.AspNetCore.Http;
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Services
{
    public class LaboratoryTestService : GenericService<SaveLaboratoryTestViewModel,LaboratoryTestViewModel,LaboratoryTest>, ILaboratoryTestService
    {
        protected readonly ILaboratoryTestRepository _laboratoryTestRepository;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly User userLogged;
        public LaboratoryTestService(IHttpContextAccessor _contextAccessor,ILaboratoryTestRepository _laboratoryTestRepository, IMapper _mapper) : base(_laboratoryTestRepository,_mapper)
        {
            this._laboratoryTestRepository = _laboratoryTestRepository;
            this._mapper = _mapper;
            this._contextAccessor = _contextAccessor;
            userLogged = _contextAccessor.HttpContext.Session.Get<User>("user");
        }

        public async Task<List<LaboratoryTestViewModel>> GetAllViewModelFromUser()
        {
           IEnumerable<LaboratoryTest> laboratoryTests= await _laboratoryTestRepository.GetAllAsync();

            return _mapper.Map<List<LaboratoryTestViewModel>>(laboratoryTests.Where(LabTest=>LabTest.ConsultingRoomId==userLogged.ConsultingRoomId));
        }
    }
}
