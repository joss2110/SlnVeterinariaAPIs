namespace PrjVeterinariaAPIs.Models
{
    public class PA_LISTAR_STOCKS
    {
        public int idstock { get; set; }
        public string codbar { get; set; }
        public string nompro { get; set; }
        public string imagen { get; set; }
        public string color { get; set; }
        public int talla { get; set; }
        public decimal precio { get; set; }

        public int cantidad { get; set; }
    }
}