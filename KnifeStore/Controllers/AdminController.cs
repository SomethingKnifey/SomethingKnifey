using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Controllers
{
    [Authorize(Policy ="AdminOnly")]
	public class AdminController : Controller, IInventory
	{

		/// <summary>
		/// sets internal DbContext variable
		/// </summary>
		private KnifeDbContext _context;

		/// <summary>
		/// sets internal variable to DbContext of Knife Model
		/// </summary>
		/// <param name="context">context to set for internal variable</param>
		/// 
		public AdminController(KnifeDbContext context)
		{
			_context = context;
		}

        /// <summary>
        /// admin index page action
        /// </summary>
        /// <returns>admin index view</returns>
		public IActionResult Index()
		{
			return View();
		}

        /// <summary>
        /// method to redirect user to create form
        /// </summary>
        /// <returns>form view</returns>
		public IActionResult CreateKnife()
		{
			return View();
		}

        /// <summary>
        /// method to create new knife
        /// </summary>
        /// <param name="knife">knife object data from form</param>
        /// <returns>new knife to db, admin to list view</returns>
		[HttpPost]
		public async Task<IActionResult> CreateKnife(Knife knife)
		{
            Knife newKnife = new Knife
            {
                Model = knife.Model,
                Image = knife.Image,
                Description = knife.Description,
                Style = knife.Style,
                Price = knife.Price
            };

            _context.Knives.Add(knife);
			await _context.SaveChangesAsync();

			return RedirectToAction("GetKnives", "Admin");
		}

        /// <summary>
        /// method to delete knife
        /// </summary>
        /// <param name="id">nullable int primary key id from database</param>
        /// <returns>admin to list view</returns>
		public async Task<IActionResult> DeleteKnife(int? id)
		{
			var deleteThis = await _context.Knives.FirstOrDefaultAsync(x => x.ID == id);

			if (deleteThis == null)
			{
				return NotFound();
			}

			_context.Knives.Remove(deleteThis);
			await _context.SaveChangesAsync();

			return RedirectToAction("GetKnives", "Admin");
		}

        /// <summary>
        /// method to view knife details
        /// </summary>
        /// <param name="id">nullable integer primary key id from database</param>
        /// <returns>details view, or admin index if does not exist</returns>
		public async Task<IActionResult> GetKnife(int? id)
		{
			if (id.HasValue)
			{
				var ChosenBlade = await _context.Knives.FirstOrDefaultAsync(x => x.ID == id);
				return View(ChosenBlade);
			}

			return RedirectToAction("Index", "Admin");
		}

        /// <summary>
        /// method to get list of knives
        /// </summary>
        /// <returns>list view</returns>
		public async Task<IActionResult> GetKnives()
		{
			var AllProducts = await _context.Knives.ToListAsync();
			return View(AllProducts);
		}

        /// <summary>
        /// method to update single knife
        /// </summary>
        /// <param name="id">nullable integer id primary key from database</param>
        /// <returns>user to form view with individual knife object to update</returns>
		public async Task<IActionResult> UpdateKnife(int? id)
		{
			if (id.HasValue)
			{
				var updateThis = await _context.Knives.FirstOrDefaultAsync(a => a.ID == id);
				return View(updateThis);
			}

			return RedirectToAction("Index", "Admin");

		}

        /// <summary>
        /// method to post updates to database
        /// </summary>
        /// <param name="knife">knife object from form view</param>
        /// <returns>admin to list view with knife updated</returns>
		[HttpPost]
		public async Task<IActionResult> UpdateKnife(Knife knife)
		{
			_context.Knives.Update(knife);
			await _context.SaveChangesAsync();
			return RedirectToAction("GetKnives", "Admin");
		}
	}
}
