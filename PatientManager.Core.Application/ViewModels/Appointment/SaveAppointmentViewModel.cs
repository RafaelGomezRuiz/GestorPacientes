using PatientManager.Core.Application.Enums;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class SaveAppointmentViewModel
    {
        public int Id { get; set; }

            [DataType(DataType.Date)]
            [Required(ErrorMessage ="La fecha de la cita es requerida")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateAppointment { get; set; }

            [DataType(DataType.Time)]
            [Required(ErrorMessage = "La hora de la cita es requerida")]
        public DateTime TimeAppointment { get; set; }
            [DataType(DataType.Text)]
            [Required(ErrorMessage = "La descripcion de la cita es requerida")]
        public string Description { get; set; }

            [Required (ErrorMessage ="Is required")]
            [DataType(DataType.Text)]
        public string Status { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Es necesario asignar un doctor")]
        public int DoctorId { get; set; }
        
        public int ConsultingRoomId { get; set; }
            
            [Range(1, int.MaxValue, ErrorMessage = "Es necesario asignar un paciente")]
        public int PatientId { get; set; }

        public List<DoctorViewModel>? Doctors { get; set; }

        public List<PatientViewModel>? Patients { get; set; }
        public List<LaboratoryTestViewModel>? LaboratoryTests { get; set; }
        public List<int> LaboratoryTestIds { get; set; } = new List<int>();

    }
}
