using Microsoft.AspNetCore.Mvc;
using BidSystem.Models;
using BidSystem.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BidSystem.Models.ViewModel;
using System.Diagnostics;

namespace BidSystem.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }
		public async Task<IActionResult> Index()
		{
			var list = await _itemService.FindAllAsync();
			return View(list);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Item item)
		{
			if (!ModelState.IsValid)
			{	
				return View(item);
			}
			await _itemService.InsertAsync(item);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided" });
			}

			var obj = await _itemService.FindByIdAsync(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _itemService.RemoveAsync(id);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception e)
			{
				return RedirectToAction(nameof(Error), new { message = e.Message });
			}
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided" });
			}

			var item = await _itemService.FindByIdAsync(id.Value);
			if (item == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			return View(item);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided" });
			}

			var item = await _itemService.FindByIdAsync(id.Value);
			if (item == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}
			return View(item);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Item item)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (id != item.Id)
			{
				return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
			}
			try
			{
				await _itemService.UpdateAsync(item);
				return RedirectToAction(nameof(Index));
			}
			catch (ApplicationException e)
			{
				return RedirectToAction(nameof(Error), new { message = e.Message });
			}
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
