using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application.ViewModels.LaboratoryResult
{
    public class SaveReportLaboratoryResultViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Es necesario una descipcion de los resultados")]
        public string Descripcion { get; set; }
    }
}
