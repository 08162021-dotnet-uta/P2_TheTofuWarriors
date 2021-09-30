using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class IngredientsController : ControllerBase
	{
		private IIngredientRepository _ingredients;
		public IngredientsController(IIngredientRepository ingredients)
		{
			_ingredients = ingredients;
		}

		[HttpGet]
		public async Task<List<ViewModelIngredient>> GetIngredients()
		{
			return await _ingredients.GetAllIngredients();
		}
	}
}
