﻿using BidSystem.Models;
using BidSystem.Models.Enums;
using BidSystem.Models.ViewModel;
using BidSystem.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BidSystem.Controllers
{
	public class StockMovementsController : Controller
	{
		private readonly StockMovementService _stockMovementService;
		private readonly ItemService _itemService;

		public StockMovementsController(StockMovementService stockMovementService, ItemService stockItemService)
		{
			_stockMovementService = stockMovementService;
			_itemService = stockItemService;
		}
		public async Task<IActionResult> Index()
		{
			var list = await _stockMovementService.FindAllAsync();
			return View(list);
		}

		public async Task<IActionResult> Create()
		{
			var items = await _itemService.FindAllAsync();
			var viewModel = new StockMovementFormViewModel { Items = items };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(StockMovement stockMovement)
		{
			await _stockMovementService.InsertAsync(stockMovement);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided" });
			}

			var stockMovement = await _stockMovementService.FindByIdAsync(id.Value);
			if (stockMovement == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			return View(stockMovement);
		}
		public IActionResult Error(string message)
		{
			var viewModel = new ErrorViewModel
			{
				Message = message,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			};
			return View(viewModel);
		}
	}
}
