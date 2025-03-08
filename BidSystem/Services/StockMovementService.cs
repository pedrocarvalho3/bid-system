using BidSystem.Data;
using BidSystem.Models;
using BidSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace BidSystem.Services
{
	public class StockMovementService
	{
		private readonly BidSystemContext _context;
		private readonly ItemService _itemService;

		public StockMovementService(BidSystemContext context)
		{
			_context = context;
		}

		public async Task<List<StockMovement>> FindAllAsync()
		{
			return await _context.StockMovement.Include(x => x.Item).ToListAsync();
		}
		public async Task InsertAsync(StockMovement obj)
		{
			bool isEntry = obj.Type == StockMovementType.Prohibited;
			await _itemService.UpdateStockAsync(obj.ItemId, obj.Quantity, isEntry);
			_context.Add(obj);
			await _context.SaveChangesAsync();
		}

		public async Task<StockMovement> FindByIdAsync(int id)
		{
			return await _context.StockMovement.FirstOrDefaultAsync(i => i.Id == id);
		}
	}
}
