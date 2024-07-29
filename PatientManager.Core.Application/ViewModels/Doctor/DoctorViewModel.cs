using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdCard { get; set; }
        public string? Photo { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoomViewModel ConsultingRoom { get; set; }
        public List<AppointmentViewModel> Appointments { get; set; }

    }
}
