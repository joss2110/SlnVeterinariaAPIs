namespace PrjVeterinariaAPIs.Models
{
    public class Users
    {
        public int iduser { get; set; }
        public string nombres { get; set; } = String.Empty;
        public int tipoDocumento { get; set; }
        public string nroDocumento { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }
}
