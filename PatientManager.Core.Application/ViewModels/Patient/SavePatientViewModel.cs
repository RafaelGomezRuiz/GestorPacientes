using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su nombre")]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su apellido")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su Address")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su IdCard")]
        public string IdCard { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su numero de telefono")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Introduzca su numero fecha de nacimiento")]
        public DateTime BornDay { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Es requerido")]
        public bool Smocker { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Es requerido")]
        public bool Allergic { get; set; }

        public string? Photo { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
