using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnifeStore.Data;
using KnifeStore.Models;
using KnifeStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnifeStore.Controllers
{
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

		public Task<IActionResult> CreateKnife(Knife knife)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> DeleteKnife(int? id)
		{
			throw new NotImplementedException();
		}

		public async Task<IActionResult> GetKnife(int? id)
		{
			if (id.HasValue)
			{
				var ChosenBlade = await _context.Knives.FirstOrDefaultAsync(x => x.ID == id);
				return View(ChosenBlade);
			}

			return RedirectToAction("Index", "Home");
		}

		public Task<IActionResult> GetKnives()
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> UpdateKnife(int? id, Knife knife)
		{
			throw new NotImplementedException();
		}
	}
}
