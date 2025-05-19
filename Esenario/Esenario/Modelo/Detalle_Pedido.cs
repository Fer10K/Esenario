using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esenario.Modelo
{
    public class Detalle_Pedido
    {
        [Key]
        public int Id_Detalle { get; set; }

        [Required]
        [ForeignKey("Pedido")]
        public int Id_Pedido { get; set; }
        public Pedido? Pedido { get; set; }

        [Required]
        [ForeignKey("Producto")]
        public int Id_Producto { get; set; }
        public Producto? Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

    }
}