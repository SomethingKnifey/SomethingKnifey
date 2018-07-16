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

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CreateKnife()
		{
			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateKnife(Knife knife)
		{
			Knife newKnife = new Knife();
			newKnife.Model = knife.Model;
			newKnife.Image = knife.Image;
			newKnife.Description = knife.Description;
			newKnife.Style = knife.Style;
			newKnife.Price = knife.Price;

			_context.Knives.Add(knife);
			await _context.SaveChangesAsync();

			return RedirectToAction("GetKnives", "Admin");
		}


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

		public async Task<IActionResult> GetKnife(int? id)
		{
			if (id.HasValue)
			{
				var ChosenBlade = await _context.Knives.FirstOrDefaultAsync(x => x.ID == id);
				return View(ChosenBlade);
			}

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> GetKnives()
		{
			var AllProducts = await _context.Knives.ToListAsync();
			return View(AllProducts);
		}

		public async Task<IActionResult> UpdateKnife(int? id)
		{
			if (id.HasValue)
			{
				var updateThis = await _context.Knives.FirstOrDefaultAsync(a => a.ID == id);
				return View(updateThis);
			}

			return RedirectToAction("Index", "Admin");

		}

		[HttpPost]
		public async Task<IActionResult> UpdateKnife(Knife knife)
		{
			_context.Knives.Update(knife);
			await _context.SaveChangesAsync();
			return RedirectToAction("GetKnives", "Admin");
		}
	}
}
