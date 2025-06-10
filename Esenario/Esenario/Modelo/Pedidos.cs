using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Esenario.Modelo
{
    public class Pedidos
    {
        [Key]
        public int Id_Pedido { get; set; }
        public DateTime Fecha_Pedido { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("Pendiente|Entregado", ErrorMessage = "El estado debe ser 'Pendiente', 'Entregado'")]
        public string Estado { get; set; } = string.Empty;
        [Required(ErrorMessage = "El total es requerido")]
        public decimal Total { get; set; } = 0.0m;

        [Required(ErrorMessage = "El cliente es requerido")]
        public int ClienteId { get; set; }
        virtual public Cliente? Cliente { get; set; }

        public virtual ICollection<DetallePedido>? Detalles { get; set; }
    }

}
