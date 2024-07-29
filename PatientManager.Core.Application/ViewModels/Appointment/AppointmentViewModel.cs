using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime DateAppointment { get; set; }
        public DateTime TimeAppointment { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }

        public List<LaboratoryResultViewModel> LaboratoryResults { get; set; }

        public int DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoomViewModel ConsultingRoom { get; set; }
        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

    }
}
