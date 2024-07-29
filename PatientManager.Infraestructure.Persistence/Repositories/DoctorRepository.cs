using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Infraestructure.Persistence.Repositories
{
    public class DoctorRepository :GenericRepository<Doctor>,IDoctorRepository
    {
        protected readonly ApplicationContext _applicationContext;
        public DoctorRepository(ApplicationContext _applicationContext) : base(_applicationContext)
        {
            this._applicationContext = _applicationContext;
        }

    }
}
