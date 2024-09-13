namespace PrjVeterinariaAPIs.Models
{
    public class Productos
    {
        public int idpro { get; set; }
        public string? codbar { get; set; } 
        public string? imagen { get; set; } 
        public string nompro { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int? talla { get; set; }
        public int idcolor { get; set; }
        public string? categoria { get; set; } 
        public string? temporada { get; set; } 
        public string? descripcion { get; set; } 
        public string estado { get; set; } =string.Empty;
    }
}
