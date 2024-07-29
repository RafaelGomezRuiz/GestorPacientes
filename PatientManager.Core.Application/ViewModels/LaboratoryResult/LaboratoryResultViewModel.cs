using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.LaboratoryResult
{
    public class LaboratoryResultViewModel
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool Status { get; set; }
        public int LaboratoryTestId { get; set; }
        public LaboratoryTestViewModel LaboratoryTest { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentViewModel Appointment { get; set; }

        public string PatientName { get; set; }
        public string IdCard { get; set; }
        public string TestName { get; set; }
    }
}
