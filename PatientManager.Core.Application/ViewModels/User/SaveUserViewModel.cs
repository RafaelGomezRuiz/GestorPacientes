using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingrese su apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ingrese su email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese su username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Es requerido el tipo de usuario")]

        public string? UserType { get; set; }

        [DataType(DataType.Text)]
        public string? ConsultingRoomName { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Las contrasenias no coinciden")]
        public string? ConfirmPassword { get; set; }
        public int ConsultingRoomId { get; set; }
    }
}
