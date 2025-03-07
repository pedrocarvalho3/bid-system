using System.ComponentModel.DataAnnotations;

namespace BidSystem.Models.Enums
{
	public enum StockMovementType
	{
		[Display(Name = "Entrada")]
		Prohibited = 0,
		[Display(Name = "Danificado")]
		Damaged = 1,
		[Display(Name = "Envio")]
		Shipped = 2,
	}
}
