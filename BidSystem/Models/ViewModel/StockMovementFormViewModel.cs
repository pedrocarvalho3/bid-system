using BidSystem.Models.Enums;

namespace BidSystem.Models.ViewModel
{
	public class StockMovementFormViewModel
	{
		public StockMovement StockMovement { get; set; }
		public StockMovementType MovementType { get; set; }
		public ICollection<Item> Items { get; set; }
	}
}
