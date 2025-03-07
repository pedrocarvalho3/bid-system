using BidSystem.Models.Enums;
using BidSystem.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace BidSystem.Data
{
	public class SeedingService
	{
		public static void Seed(BidSystemContext context)
		{
			// Aplica migrações pendentes
			context.Database.Migrate();

			// Verifica se já existem itens no banco de dados
			if (!context.Item.Any())
			{
				var items = new List<Item>
				{
					new Item { Name = "Placa de Vídeo RTX 3060", Quantity = 10, Price = 2499.99m, Description = "Placa de vídeo para gamers e criadores de conteúdo." },
					new Item { Name = "Processador Intel i7 12700K", Quantity = 5, Price = 1999.99m, Description = "Processador de alto desempenho para desktops." },
					new Item { Name = "Memória RAM 16GB DDR4", Quantity = 20, Price = 399.99m, Description = "Memória para alto desempenho e multitarefa." },
					new Item { Name = "HD SSD 1TB NVMe", Quantity = 8, Price = 899.99m, Description = "Armazenamento rápido para sistemas operacionais e jogos." }
				};

				context.Item.AddRange(items);
				context.SaveChanges();

				// Criando movimentações de estoque
				var movements = new List<StockMovement>
				{
					new StockMovement { ItemId = items[0].Id, Quantity = 10, Type = StockMovementType.Prohibited, Notes = "Compra inicial do fornecedor" },
					new StockMovement { ItemId = items[1].Id, Quantity = 5, Type = StockMovementType.Prohibited, Notes = "Compra de CPUs para revenda" },
					new StockMovement {	ItemId = items[2].Id, Quantity = 20, Type = StockMovementType.Prohibited, Notes = "Reabastecimento de memória RAM" },
					new StockMovement { ItemId = items[3].Id, Quantity = 8, Type = StockMovementType.Prohibited, Notes = "Nova remessa de SSDs" }
				};

				context.StockMovement.AddRange(movements);
				context.SaveChanges();
			}
		}
	}
}
