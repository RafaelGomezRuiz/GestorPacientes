using StockApp.Core.Domain.Common;



namespace PatientManager.Core.Domain.Entities
{
    public class Appointment : AuditableBaseEntity
    {

        public DateTime DateAppointment { get; set; }
        public DateTime TimeAppointment { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public List<LaboratoryResult> LaboratoryResults { get; set; }
        
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
