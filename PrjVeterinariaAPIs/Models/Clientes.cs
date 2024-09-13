namespace PrjVeterinariaAPIs.Models
{
    public class Clientes
    {
        public int idcli {  get; set; }
        public string nomcli { get; set; } = string.Empty;
        public string apellidos { get; set; } = "";
        public string tipodocumento { get; set; } = string.Empty;
        public string nrodocumento { get; set; } = string.Empty;
        public string? telefono { get; set; } = string.Empty;
        public string? direccion { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
    }
}
