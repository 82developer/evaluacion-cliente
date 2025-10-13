namespace Evaluacion.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string? Direccion { get; set; }
    }
}
