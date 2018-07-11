using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnifeStore.Models.Interfaces
{
   public interface IInventory
    {
		Task<IActionResult> CreateKnife(Knife knife);
		Task<IActionResult> GetKnife(int id);
		Task<IActionResult> UpdateKnife(int id, Knife knife);
		Task<IActionResult> DeleteKnife(int id);
    }
}
