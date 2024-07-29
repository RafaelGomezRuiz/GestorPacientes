using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Domain.Entities
{
    public class LaboratoryResult : AuditableBaseEntity
    {
        public string? Descripcion { get; set; }
        public bool  Status { get; set; }
        public int LaboratoryTestId { get; set; }
        public LaboratoryTest LaboratoryTest { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
