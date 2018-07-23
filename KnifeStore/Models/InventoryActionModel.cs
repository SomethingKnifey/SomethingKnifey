using KnifeStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KnifeStore.Models
{
    public class InventoryActionModel : IInventory
	{
		public Task<IActionResult> CreateKnife(Knife knife)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> DeleteKnife(int? id)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> GetKnife(int? id)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> GetKnives()
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> UpdateKnife(int? id)
		{
			throw new NotImplementedException();
		}
	}
}
