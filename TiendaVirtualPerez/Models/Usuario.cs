using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualPerez.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^3\d{9}$", ErrorMessage = "El teléfono debe iniciar por 3 y tener 10 dígitos")]
        public string celular { get; set; }
        public string Clave { get; set; }
    }
}