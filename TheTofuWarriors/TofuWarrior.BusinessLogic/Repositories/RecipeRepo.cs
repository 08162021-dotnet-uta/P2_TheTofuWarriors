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
        public RecipeRepo(TheTofuWarriorsDBContext context, ILogger<RecipeRepo> logger, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _logger = logger;
            _adamamRecipeApi = new RecipeApi.EdamamRecipeApi(httpClientFactory);
        }

		public object AdamamRecipeApi { get; private set; }

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
            
            List<Recipe> recipes = await _context.Recipes.ToListAsync();
            List<ViewModelRecipe> views = new List<ViewModelRecipe>();
            foreach(Recipe r in recipes)
            {
                views.Add(Mapper.RecipeToViewModelRecipe(r));
            }
            return views;
        }

        public async Task<ViewModelRecipe> GetItemsByIdAsync(int id)
        {
            Recipe result = await _context.Recipes.FirstOrDefaultAsync(recipe => recipe.RecipeId == id) ;
            ViewModelRecipe views = Mapper.RecipeToViewModelRecipe(result);
            return views;
        }

        public async Task<List<ViewModelRecipe>> SearchByIngredientName(string ingredientName)
        {
            var result = await _adamamRecipeApi.SearchRecipeAsync(ingredientName);
            return result.hits.Select(h=> ApiRecipeMapper.ConvertToModel(h.recipe))
                .ToList();
        }
      
    }
}
