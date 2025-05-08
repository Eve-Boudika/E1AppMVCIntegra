using System.ComponentModel.DataAnnotations;

namespace E1WebMVC.Repository.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe tener exactamente 11 dígitos")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El CUIT debe contener solo números")]
        public string Cuit { get; set; }

        [Display(Name = "Razón Social")]
        public string? RazonSocial { get; set; } 

        [Display(Name = "Teléfono")]
        [RegularExpression(@"^[0-9+ -]+$", ErrorMessage = "El teléfono debe contener solo números, +, -, o espacios")]
        public string Telefono { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres")]
        public string Direccion { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}

