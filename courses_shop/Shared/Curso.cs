using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace courses_shop.Shared
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El campo nombre obligatorio")]
        public string NombreCurso { get; set; }

        [Required(ErrorMessage = "* El campo ruta imagen obligatorio")]
        public string RutaImagen { get; set; }

        [Required(ErrorMessage = "* El campo Descripcion obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "* El campo Programa obligatorio")]
        public string Programa { get; set; }

        [Required(ErrorMessage = "* El campo fecha alta obligatorio")]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public Precio Precio { get; set; }
    }
}
