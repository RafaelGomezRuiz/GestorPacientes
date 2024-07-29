using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Services
{
    public class ConsultingRoomService : GenericService<SaveConsultingRoomViewModel, ConsultingRoomViewModel, ConsultingRoom>, IConsultingRoomService
    {
        private readonly IConsultingRoomRepository _consultingRoomRepository;
        protected readonly IMapper _mapper;

        public ConsultingRoomService(IConsultingRoomRepository _consultingRoomRepository, IMapper _mapper) : base(_consultingRoomRepository, _mapper)
        {
            this._consultingRoomRepository = _consultingRoomRepository;
            this._mapper = _mapper;
        }
    }
}
