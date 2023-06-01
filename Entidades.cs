using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public decimal MontoTotal { get; set; }

    public ICollection<ItemVenta> Items { get; set; }
}

public class ItemVenta
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Venta")]
    public int VentaId { get; set; }

    [Required]
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    [Required]
    public decimal Precio { get; set; }

    public Venta Venta { get; set; }
    public Producto Producto { get; set; }
}

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public decimal Precio { get; set; }

    public ICollection<ItemVenta> Items { get; set; }
}

