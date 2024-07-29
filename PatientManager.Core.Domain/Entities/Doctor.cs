using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Domain.Entities
{
    public class Doctor : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdCard { get; set; }
        public string? Photo { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
