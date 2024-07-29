using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string UserType { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoomViewModel ConsultingRoom { get; set; }
    }
}
