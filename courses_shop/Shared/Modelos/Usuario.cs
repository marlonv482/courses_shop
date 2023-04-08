using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses_shop.Shared.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El campo Nombre obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* El campo Apellido obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "* El campo Email obligatorio")]
        [EmailAddress(ErrorMessage = "* Formto de Email Incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*El campo Password obligatorio")]
        public string Password { get; set; }

        
        public DateTime? FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public List<Curso>? ListaCursos { get; set; }
    }
}
