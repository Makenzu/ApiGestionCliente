using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ApiGestionCliente.Models
{
    public class Client
    {
        [Key]
        [ReadOnly(true)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Rut { get; set; }
        
        [Required] 
        public string Nombre { get; set; }

        public string? ApePaterno { get; set; }


        public string? ApeMaterno { get; set; }

        [Required] 
        public string? Email { get; set; }


        public string? Celular { get; set; }

        [Required]
        public string? Empresa { get; set; }
    }
}
