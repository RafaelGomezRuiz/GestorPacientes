using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? IdCard { get; set; }
        public DateTime BornDate { get; set; }
        public bool Smocker { get; set; }
        public bool Allergic { get; set; }
        public string? Photo { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoomViewModel ConsultingRoom { get; set; }
        public IEnumerable<LaboratoryResultViewModel> LaboratoryResults { get; set; }


    }
}
