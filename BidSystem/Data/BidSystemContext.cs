using Microsoft.EntityFrameworkCore;
using BidSystem.Models;

namespace BidSystem.Data
{
    public class BidSystemContext : DbContext
    {
        public BidSystemContext (DbContextOptions<BidSystemContext> options)
            : base(options)
        {
        }

        public DbSet<StockItem> StockItem { get; set; } = default!;
		public DbSet<StockMovement> StockMovement { get; set; } = default!;
	}
}
