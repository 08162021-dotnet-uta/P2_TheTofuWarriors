using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRepository _recipe;
        public RecipeController(IRepository recipe)
        {
            _recipe = recipe;
        }


		/// <summary>
		/// Add a recipe to database (only affects Recipe table)
		/// </summary>
		/// <param name="recipe"></param>
		/// <returns></returns>
        [HttpPost("AddRecipe")]
        public async Task AddRecipe(ViewModelRecipe recipe)
        {
            await _recipe.CreateItemAsync(recipe);
        }

		public class UserRecipeData
		{
			public ViewModelRecipe recipe { get; set; }
			public ViewModelUser user { get; set; }
		}

		/// <summary>
		/// Add/update a recipe in the database (including all accompanying data)
		/// </summary>
		/// <returns></returns>
		[HttpPost("SaveUserRecipe")]
		public async Task<ViewModelRecipe> AddUserRecipe(UserRecipeData data)
		{
			return await _recipe.SaveUserRecipe(data.recipe, data.user);
		}

        [HttpGet("GetAllRecipes")]
        public async Task<List<ViewModelRecipe>> GetAllRecipes()
        {
            var recipeList = await _recipe.GetAllItemAsync();
            return recipeList;

        }
        [HttpGet("GetRecipeById")]
        public async Task<ViewModelRecipe> GetRecipe(int id)
        {
            var recipe = await _recipe.GetItemsByIdAsync(id);
            return recipe;
        }

        [HttpGet("DeleteRecipe")]
        public async Task DeleteRecipe(ViewModelRecipe recipe)
        {
            await _recipe.DeleteItemAsync(recipe);
        }

        [HttpPost("Search")]
        public async Task<List<ViewModelRecipe>> SearchRecipes(RecipeSearchTerms data)
        {
            return await _recipe.SearchRecipes(data.terms, data.tags);
        }

		public class RecipeSearchTerms
		{
			public List<string> terms { get; set; }
			public List<ViewModelTag> tags { get; set; }
		}

    }
}
