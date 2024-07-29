using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Domain.Entities
{
    public class ConsultingRoom : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Doctor> Doctors { get; set; }
        public virtual IEnumerable<LaboratoryTest> LaboratoryTests { get; set; }
        public virtual IEnumerable<Patient> Patients { get; set; }
        public virtual IEnumerable<LaboratoryResult> LaboratoryResults { get; set; }

    }
}
