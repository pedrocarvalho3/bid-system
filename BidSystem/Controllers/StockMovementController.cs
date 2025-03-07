using BidSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidSystem.Controllers
{
	public class StockMovementController : Controller
	{
		private readonly StockMovementService _stockMovementService;
		private readonly StockItemService _stockItemService;

		public StockMovementController(StockMovementService stockMovementService, StockItemService stockItemService)
		{
			_stockMovementService = stockMovementService;
			_stockItemService = stockItemService;
		}
		public async Task<IActionResult> Index()
		{
			var list = await _stockMovementService.FindAllAsync();
			return View(list);
		}
	}
}
