using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.UpdateExperience
{
    public class InstitutionPatchDTO
    {
        // De Institution
        [Required(ErrorMessage = "El nombre de la institución es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre de la institución no debe superar los 150 caracteres")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "El departamento es obligatorio")]
        [StringLength(100, ErrorMessage = "El departamento no debe superar los 100 caracteres")]
        public string Department { get; set; } = string.Empty;



        [Required(ErrorMessage = "El municipio es obligatorio")]
        [StringLength(100, ErrorMessage = "El municipio no debe superar los 100 caracteres")]
        public string Municipality { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código DANE es obligatorio")]
        [StringLength(10, ErrorMessage = "El código DANE debe ser numérico y tener entre 5 y 10 dígitos")]
        public string CodeDane { get; set; } = string.Empty;

    }
}
