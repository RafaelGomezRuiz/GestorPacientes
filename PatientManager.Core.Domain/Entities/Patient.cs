using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientManager.Core.Domain.Entities
{
    public class Patient : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? IdCard { get; set; }
        public DateTime BornDate { get; set; }
        public bool Smocker { get; set; }
        public bool Allergic { get; set; }
        public string? Photo {  get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom? ConsultingRoom { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<LaboratoryResult> LaboratoryResults { get; set; }

    }
}
