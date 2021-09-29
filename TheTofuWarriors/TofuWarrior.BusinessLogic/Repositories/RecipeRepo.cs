using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;
using TofuWarrior.BusinessLogic.Interfaces;
using System.Net.Http;
using RecipeApi = TofuWarrior.BusinessLogic.Api;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class RecipeRepo: IRepository

    {
        private readonly TheTofuWarriorsDBContext _context;
        private readonly ILogger<RecipeRepo> _logger;
        private readonly RecipeApi.EdamamRecipeApi _adamamRecipeApi;
        public RecipeRepo(TheTofuWarriorsDBContext context, ILogger<RecipeRepo> logger, RecipeApi.EdamamRecipeApi recipeApi)
        {
            _context = context;
            _logger = logger;
			//_adamamRecipeApi = new RecipeApi.EdamamRecipeApi(httpClientFactory);
			_adamamRecipeApi = recipeApi;
        }

		public async Task<Recipe> CreateItemAsync(ViewModelRecipe item)
        {
            Recipe r = Mapper.ViewModelRecipeToRecipe(item);
            _context.Recipes.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<Recipe> DeleteItemAsync(ViewModelRecipe item)
        {
            Recipe r = Mapper.ViewModelRecipeToRecipe(item);
            _context.Recipes.Remove(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<List<ViewModelRecipe>> GetAllItemAsync()
        {
            
            List<Recipe> recipes = await _context.Recipes
				.Include(r => r.CreatorUser)
				.Include(r => r.RecipeIngredients)
				.ThenInclude(ri => ri.Ingredient)
				.ToListAsync();
            List<ViewModelRecipe> views = new List<ViewModelRecipe>();
            foreach(Recipe r in recipes)
            {
				_logger.LogInformation("Recipe ingredient count: {0}", r.RecipeIngredients.Count);
                views.Add(Mapper.ConvertToModel(r));
            }
            return views;
        }

        public async Task<ViewModelRecipe> GetItemsByIdAsync(int id)
        {
            Recipe result = await _context.Recipes
				.Include(r => r.CreatorUser)
				.Include(r => r.RecipeIngredients)
				.ThenInclude(ri => ri.Ingredient)
				.FirstOrDefaultAsync(recipe => recipe.RecipeId == id) ;
            ViewModelRecipe views = Mapper.ConvertToModel(result);
            return views;
        }

        public async Task<List<ViewModelRecipe>> SearchRecipes(List<string> ingredientNames, List<ViewModelTag> tags)
        {
            var result = await _adamamRecipeApi.SearchRecipeAsync(ingredientNames, tags);
            return result.hits.Select(h=> ApiRecipeMapper.ConvertToModel(h.recipe))
                .ToList();
        }
      
    }
}
