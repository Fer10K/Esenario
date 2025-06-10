using System.ComponentModel.DataAnnotations;

namespace Esenario.Modelo
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre es requerido y máximo 100 caracteres")]
        public string Nombre { get; set; } = "";

        [Required]
        [StringLength(10, ErrorMessage = "El Teléfono es requerido y máximo 10 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "La dirección es requerida y máximo 100 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "El correo es requerido y máximo 100 caracteres")]
        public string Correo { get; set; } = string.Empty;
    }
}
