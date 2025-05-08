namespace E1WebMVC.Service.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Cuit { get; set; }
        public string? RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
