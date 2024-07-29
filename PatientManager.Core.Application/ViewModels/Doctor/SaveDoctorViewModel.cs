using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.Doctor
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Introduzca su nombre")]
        public string? Name { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su apellido")]
        public string? LastName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su Email")]
        public string? Email { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su numero telefonico")]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Introduzca su idCard")]
        public string? IdCard { get; set; }

        public string?  Photo { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
