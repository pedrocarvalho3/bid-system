using BidSystem.Data;
using BidSystem.Models;
using BidSystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;

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

		public async Task InsertAsync(Item item)
		{
			_context.Item.Add(item);
			await _context.SaveChangesAsync();
		}

		public async Task<Item> FindByIdAsync(int id)
		{
			return await _context.Item.FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task RemoveAsync(int id)
		{
			try
			{
				var obj = await _context.Item.FindAsync(id);
				_context.Item.Remove(obj);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException e)
			{
				throw new IntegrityException("Can't delete seller because he/she has sales");
			}
		}

		public async Task UpdateAsync(Item obj)
		{
			var existingItem = await _context.Item.FindAsync(obj.Id);
			if (existingItem == null)
			{
				throw new NotFoundException("Id not found");
			}

			try
			{
				obj.Quantity = existingItem.Quantity;

				_context.Entry(existingItem).CurrentValues.SetValues(obj);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}
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
