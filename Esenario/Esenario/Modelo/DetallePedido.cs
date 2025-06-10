using Esenario.Modelo;
using System.ComponentModel.DataAnnotations;

public class DetallePedido
{
    [Key]
    public int IdDetalle { get; set; }

    public int PedidoId { get; set; }

    public virtual Pedidos? Pedido { get; set; }

    public int ProductoId { get; set; }
    public virtual Producto? Producto { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida")]
    public int Cantidad { get; set; }

    public decimal Subtotal { get; set; }
}
