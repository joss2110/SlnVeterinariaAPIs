namespace PrjVeterinariaAPIs.Models
{
    public class PA_LISTAR_INGRESOS
    {
        public int idingre { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string nombres { get; set; }
        public string imagen { get; set; }
        public int idpro { get; set; }
        public string nompro { get; set; }
        public string color { get; set; }
        public string talla { get; set; }
        public int cantidad { get; set; }
    }
}
