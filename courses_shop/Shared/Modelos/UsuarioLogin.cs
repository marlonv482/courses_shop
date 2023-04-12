using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses_shop.Shared.Modelos
{
    public class UsuarioLogin
    {
        public int Id { get; set; }

       

        [Required(ErrorMessage = "* El campo Email obligatorio")]
        [EmailAddress(ErrorMessage = "* Formto de Email Incorrecto")]
        public string EmailLogin { get; set; }

        [Required(ErrorMessage = "*El campo Password obligatorio")]
        public string Password { get; set; }

        
    }
}