using System.ComponentModel.DataAnnotations;

namespace Esenario.Modelo
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(15, ErrorMessage = "El nombre debe tener un máximo de 15 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100, ErrorMessage = "La descripción debe tener un máximo de 100 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La disponibilidad es requerida")]
        [RegularExpression("Disponible|No Disponible", ErrorMessage = "La categoría debe ser 'Disponible' o 'No disponible'.")]
        public string Disponible { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es requerida")]
        [RegularExpression("Bebida|Postre", ErrorMessage = "La categoría debe ser 'Bebida' o 'Postre'.")]
        public string Categoria { get; set; } = string.Empty;

        public virtual ICollection<DetallePedido>? Detalles { get; set; }
    }
}
