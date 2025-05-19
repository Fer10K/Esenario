using System.ComponentModel.DataAnnotations;

namespace Esenario.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage ="El telefono es requerido")]
        [StringLength(10, ErrorMessage ="Maximo 10 caracteres")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage ="La direccion es requerida")]
        [StringLength(100, ErrorMessage ="Maximo 100 caracteres")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage ="El correo es requerido")]
        [EmailAddress(ErrorMessage ="Debe ser un correo válido")]
        [StringLength(100, ErrorMessage ="Maximo 100 caracteres")]
        public string? Correo { get; set; }
    }
}
