using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.ViewModels.ConsultingRoom
{
    public class ConsultingRoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<UserViewModel> Users { get; set; }
        public virtual IEnumerable<DoctorViewModel> Doctors { get; set; }
        public virtual IEnumerable<LaboratoryTestViewModel> LaboratoryTests { get; set; }
        public virtual IEnumerable<PatientViewModel> Patients { get; set; }

    }
}
