using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.LaboratoryTest
{
    public class SaveLaboratoryTestViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="El nombre de la prueba es requerido")]
        public string? Name { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
