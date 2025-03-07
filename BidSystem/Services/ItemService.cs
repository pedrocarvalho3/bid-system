using BidSystem.Data;
using BidSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BidSystem.Services
{
	public class ItemService
	{
		private readonly BidSystemContext _context;

		public ItemService(BidSystemContext context)
		{
			_context = context;
		}

		public async Task<List<Item>> FindAllAsync()
		{
			return await _context.Item.ToListAsync();
		}

		public async Task UpdateStockAsync(int itemId, int quantity, bool isEntry)
		{
			var item = await _context.Item.FindAsync(itemId);
			if (item == null)
			{
				throw new InvalidOperationException("Item não encontrado.");
			}

			if (isEntry)
			{
				item.Quantity += quantity;
			}
			else
			{
				if (item.Quantity < quantity)
				{
					throw new InvalidOperationException("Estoque insuficiente.");
				}
				item.Quantity -= quantity;
			}

			await _context.SaveChangesAsync();
		}
	}
}
