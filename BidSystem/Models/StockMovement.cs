using System.ComponentModel.DataAnnotations;

namespace BidSystem.Models
{
	public class StockMovement
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int ItemId { get; set; }
		public Item Item { get; set; }
		[Required]
		public int Quantity { get; set; }
		[Required]
		public StockMovementType Type { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string? Notes { get; set; }

		public StockMovement()
		{

		}

		public StockMovement(int id, int itemId, Item item, int quantity, StockMovementType type, DateTime date, string? notes)
		{
			Id = id;
			ItemId = itemId;
			Item = item;
			Quantity = quantity;
			Type = type;
			Date = date;
			Notes = notes;
		}
	}
}
