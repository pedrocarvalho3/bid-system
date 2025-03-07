using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidSystem.Models
{
	public class StockItem
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public int Quantity { get; set; }
		[Required]
		public decimal Price { get; set; }
		public string? Description { get; set; }

		public StockItem()
		{
		}

		public StockItem(string name, int quantity, decimal price, string? description, int stockMovementId)
		{
			Name = name;
			Quantity = quantity;
			Price = price;
			Description = description;
		}

		public StockItem(int id, string name, int quantity, decimal price, string? description, int stockMovementId)
		{
			Id = id;
			Name = name;
			Quantity = quantity;
			Price = price;
			Description = description;
		}
	}
}
