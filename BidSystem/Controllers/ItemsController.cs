using Microsoft.AspNetCore.Mvc;
using BidSystem.Models;
using BidSystem.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

		// GET: Items/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var item = await _itemService.FindByIdAsync(id.Value);
			if (item == null)
			{
				return NotFound();
			}

			return View(item);
		}

		// GET: Departments/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Departments/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Item item)
		{
			if (ModelState.IsValid)
			{
				await _itemService.InsertAsync(item);
				return RedirectToAction(nameof(Index));
			}
			return View(item);
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

		// GET: Departments/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var department = await _itemService.FindByIdAsync(id.Value);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

		// POST: Departments/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

		// GET: Departments/Delete/5
		/*public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var department = await _context.Department
				.FirstOrDefaultAsync(m => m.Id == id);
			if (department == null)
			{
				return NotFound();
			}

			return View(department);
		}

		// POST: Departments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var department = await _context.Department.FindAsync(id);
			_context.Department.Remove(department);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DepartmentExists(int id)
		{
			return _context.Department.Any(e => e.Id == id);
		}*/
	}
}
