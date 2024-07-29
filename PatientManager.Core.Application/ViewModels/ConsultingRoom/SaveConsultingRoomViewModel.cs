using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.ConsultingRoom
{
    public class SaveConsultingRoomViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Es necesario este valor")]
        public string? Name { get; set; }
    }
}
