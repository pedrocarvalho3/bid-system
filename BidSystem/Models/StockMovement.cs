using BidSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BidSystem.Models
{
	public class StockMovement
	{
		[Key]
		[Display(Name = "Código")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Quantidade")]
		public int Quantity { get; set; }
		[Required]
		[Display(Name = "Tipo")]
		public StockMovementType Type { get; set; }
		[Display(Name = "Data")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime Date { get; set; } = DateTime.Now;
		[Display(Name = "Notas")]
		public string? Notes { get; set; }
		[Required]
		[Display(Name = "Código do Item")]
		public int ItemId { get; set; }
		public Item Item { get; set; }

		public StockMovement()
		{

		}

		public StockMovement(int itemId, int quantity, StockMovementType type, DateTime date, string? notes)
		{
			ItemId = itemId;
			Quantity = quantity;
			Type = type;
			Date = date;
			Notes = notes;
		}

		public StockMovement(int id, int itemId, int quantity, StockMovementType type, DateTime date, string? notes)
		{
			Id = id;
			ItemId = itemId;
			Quantity = quantity;
			Type = type;
			Date = date;
			Notes = notes;
		}
	}
}
