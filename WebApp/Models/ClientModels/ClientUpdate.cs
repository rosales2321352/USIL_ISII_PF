namespace WebApp.Models
{
    public class ClientUpdate
    {
        public int PersonID { get; set; }
        public int ClientStatusID { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!; //REMOVER NO SE PUEDE EDITAR UNA VEZ CREADO
        public string WhatsappID { get; set; } = null!;
        public int? CompanyID { get; set; }
    }
}