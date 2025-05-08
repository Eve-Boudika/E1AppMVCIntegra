using System.ComponentModel.DataAnnotations;

namespace E1WebMVC.Repository.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Cuit { get; set; }
        public string? RazonSocial { get; set; } 
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}

