using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Domain.Entities
{
    public class LaboratoryTest : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
        public List<LaboratoryResult> LaboratoryResults { get; set; }
    }
}
