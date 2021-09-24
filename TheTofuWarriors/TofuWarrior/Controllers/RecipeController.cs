using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic;

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
        [HttpPost("AddRecipe")]
        public async Task AddRecipe(ViewModelRecipe recipe)
        {
            await _recipe.CreateItemAsync(recipe);
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

    }
}
