using BidSystem.Data;
using BidSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BidSystem.Services
{
	public class StockMovementService
	{
		private readonly BidSystemContext _context;

		public StockMovementService(BidSystemContext context)
		{
			_context = context;
		}

		public async Task<List<StockMovement>> FindAllAsync()
		{
			return await _context.StockMovement.ToListAsync();
		}
	}
}
