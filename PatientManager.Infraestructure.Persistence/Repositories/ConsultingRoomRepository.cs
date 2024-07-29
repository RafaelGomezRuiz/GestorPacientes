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
    public class ConsultingRoomRepository : GenericRepository<ConsultingRoom>, IConsultingRoomRepository
    {
        protected readonly ApplicationContext _dbContext;
        public ConsultingRoomRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

    }
}
