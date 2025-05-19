using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esenario.Modelo
{
    public class Pedido
    {
        [Key]
        public int Id_Pedido { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }
        public Cliente? Cliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "pendiente";

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public ICollection<Detalle_Pedido>? Detalles { get; set; }
    }
}