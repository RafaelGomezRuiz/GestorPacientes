using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class SaveConsultAppointmentViewModel
    {
        public int Id { get; set; }
        public List<LaboratoryTestViewModel>? LaboratoryTests{ get; set; }
        [Required(ErrorMessage ="Es necesario elegir una o mas pruebas de lab")]
        public List<int> LaboratoryTestIds { get; set; } 

    }
}
