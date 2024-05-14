using System.ComponentModel.DataAnnotations; // To use [Required].
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics; // To use [Column].

namespace Northwind.EntityModels;

[DebuggerDisplay("{ProductId}: {ProductName}")]
public class Product
{
  public int ProductId { get; set; } // The primary key.

  [StringLength(40)]
  public string ProductName { get; set; } = null!;

  [Column(TypeName = "money")]
  public decimal? UnitPrice { get; set; }

  public short? UnitsInStock { get; set; }

  public bool Discontinued { get; set; }

  // These two properties define the foreign key relationship
  // to the Categories table.
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; } = null!;
}
