namespace PrjVeterinariaAPIs.Models
{
    public class Trabajadores
    {
        public int idtra { get; set; }
        public string nombres { get; set; } = String.Empty;
        public string tipoDocumento { get; set; } = String.Empty;
        public string nroDocumento { get; set; } = String.Empty;
        public string direccion { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string pass { get; set; } = String.Empty;
        public int idrol { get; set; }
        public string estado { get; set; } = String.Empty;
    }
}
