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
    public class AppointmentRepository : GenericRepository<Appointment> , IAppointmentRepository
    {
        protected readonly ApplicationContext _applicationContext;
        public AppointmentRepository(ApplicationContext _applicationContext) : base(_applicationContext)
        {
            this._applicationContext = _applicationContext;
        }
    }
}
