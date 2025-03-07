using BidSystem.Data;
using BidSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BidSystem.Services
{
	public class StockItemService
	{
		private readonly BidSystemContext _context;

		public StockItemService(BidSystemContext context)
		{
			_context = context;
		}

		public async Task<List<StockItem>> FindAllAsync()
		{
			return await _context.StockItem.ToListAsync();
		}
	}
}
