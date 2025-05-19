using System.ComponentModel.DataAnnotations;

namespace Esenario.Modelo
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal Precio { get; set; }

        [Required]
        public bool Disponibilidad { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria { get; set; } = string.Empty;
    }
}