using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidSystem.Models
{
	public class Item
	{
		[Key]
		[Display(Name = "Código")]
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nome")]
		public string Name { get; set; } = string.Empty;
		[Required]
		[Display(Name = "Quantidade")]
		public int Quantity { get; set; }
		[Required]
		[Display(Name = "Preço")]
		public decimal Price { get; set; }
		[Display(Name = "Descrição")]
		public string? Description { get; set; }

		public Item()
		{
		}

		public Item(string name, int quantity, decimal price, string? description, int stockMovementId)
		{
			Name = name;
			Quantity = 0;
			Price = price;
			Description = description;
		}

		public Item(int id, string name, int quantity, decimal price, string? description, int stockMovementId)
		{
			Id = id;
			Name = name;
			Quantity = 0;
			Price = price;
			Description = description;
		}
	}
}
