using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IConsultingRoomService : IGenericService<SaveConsultingRoomViewModel, ConsultingRoomViewModel, ConsultingRoom>
    {
    }
}
