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
		[Display(Name = "Descrição")]
		public string? Notes { get; set; }
		[Required]
		[Display(Name = "Código do Item")]
		public int StockItemId { get; set; }
		public StockItem StockItem { get; set; }

		public StockMovement()
		{

		}

		public StockMovement(int itemId, int quantity, StockMovementType type, DateTime date, string? notes)
		{
			StockItemId = itemId;
			Quantity = quantity;
			Type = type;
			Date = date;
			Notes = notes;
		}

		public StockMovement(int id, int itemId, int quantity, StockMovementType type, DateTime date, string? notes)
		{
			Id = id;
			StockItemId = itemId;
			Quantity = quantity;
			Type = type;
			Date = date;
			Notes = notes;
		}
	}
}
