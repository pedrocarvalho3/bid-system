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

        public DbSet<Item> Item { get; set; } = default!;
		public DbSet<StockMovement> StockMovement { get; set; } = default!;
	}
}
