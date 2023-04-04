using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace courses_shop.Shared
{
    public class Precio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El campo precio de venta obligatorio")]
        public double PrecioVenta { get; set; }

        [Required(ErrorMessage = "*El campo fecha de inicio obligatorio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "*El campo fecha fin obligatorio")]
        public DateTime? FechaFin { get; set; }
    }
}
