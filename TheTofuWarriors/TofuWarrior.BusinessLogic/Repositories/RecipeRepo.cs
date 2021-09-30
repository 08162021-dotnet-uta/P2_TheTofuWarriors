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

		/// <summary>
		/// add recipe to database (only affects recipe table)
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<Recipe> CreateItemAsync(ViewModelRecipe item)
        {
            Recipe r = Mapper.ViewModelRecipeToRecipe(item);
            _context.Recipes.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

		private async Task<List<RecipeIngredient>> CreateRecipeIngredients(ViewModelRecipe recipe)
		{
			List<RecipeIngredient> result = new();
			foreach (var ingredient in recipe.Ingredients)
			{
				Ingredient dbIngredient = await (from i in _context.Ingredients where i.IngredientId == ingredient.IngredientId select i).FirstAsync();
				MeasureUnit dbMeasure = await (from m in _context.MeasureUnits where m.MeasureUnitId == ingredient.MeasureUnitId select m).FirstAsync();
				result.Add(new RecipeIngredient()
				{
					Quantity = ingredient.Quantity,
					Ingredient = dbIngredient,
					IngredientId = dbIngredient.IngredientId,
					MeasureUnit = dbMeasure,
					MeasureUnitId = dbMeasure.MeasureUnitId,
				});
			}
			return result;
		}

		/// <summary>
		/// add/update recipe in database (updates all linking tables)
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task<ViewModelRecipe> SaveUserRecipe(ViewModelRecipe recipe, ViewModelUser user)
		{
			var dbUser = await (from u in _context.Users where u.UserId == user.UserId select u).FirstAsync();
			Recipe newRecipe;
			if (recipe.RecipeId == 0)
			{
				newRecipe = new Recipe();
			} else
			{
				newRecipe = await (from r in _context.Recipes where r.RecipeId == recipe.RecipeId select r)
					.Include(r => r.RecipeIngredients)
					.Include(r => r.RecipeTags)
					.FirstAsync();
			}
			newRecipe.CreatorUserId = recipe.CreatorUserId;
			newRecipe.Instructions = recipe.Instructions;
			newRecipe.Name = recipe.Name;
			if (recipe.RecipeId != 0)
			{
				_context.RecipeIngredients.RemoveRange(newRecipe.RecipeIngredients);
				await _context.SaveChangesAsync();
				newRecipe.RecipeIngredients.Clear();
			}
			newRecipe.RecipeIngredients = await CreateRecipeIngredients(recipe);
				//TODO: make tags work
			newRecipe.RecipeTags = new List<RecipeTag>();
			newRecipe.CreatorUser = dbUser;
			if (recipe.RecipeId == 0)
			{
				_context.Recipes.Add(newRecipe);
			}
			if (recipe.RecipeId != 0)
			{
				UserRecipe newUR = new()
				{
					User = dbUser,
					UserId = dbUser.UserId,
					// TODO: Fix apikey type
					//ApiRecipeKey = recipe.ApiKey,
					Recipe = newRecipe,
				};
				_context.UserRecipes.Add(newUR);
			}
			_context.RecipeIngredients.AddRange(newRecipe.RecipeIngredients);
			await _context.SaveChangesAsync();
			return Mapper.ConvertToModel(newRecipe);
		}

        public async Task<Recipe> DeleteItemAsync(ViewModelRecipe item)
        {
            Recipe r = Mapper.ViewModelRecipeToRecipe(item);
            _context.Recipes.Remove(r);
            await _context.SaveChangesAsync();
            return r;
        }

		private IQueryable<Recipe> GetRecipesBaseQuery()
		{
			return _context.Recipes
				.Include(r => r.CreatorUser)
				.Include(r => r.RecipeIngredients)
				.ThenInclude(ri => ri.Ingredient)
				.Include(r => r.RecipeIngredients)
				.ThenInclude(ri => ri.MeasureUnit);
		}
			public async Task<List<ViewModelRecipe>> GetUserRecipes(int userId)
		{
			var userRecipes = await GetRecipesBaseQuery().Where(r=>r.CreatorUserId == userId).ToListAsync();
			// (from u in _dbc.Users where u.UserId == userId select u.Recipes).FirstAsync();
			return userRecipes.ToList().ConvertAll(Mapper.ConvertToModel);
		}


        public async Task<List<ViewModelRecipe>> GetAllItemAsync()
        {

			List<Recipe> recipes = await GetRecipesBaseQuery().ToListAsync();
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
            Recipe result = await GetRecipesBaseQuery()
				.FirstOrDefaultAsync(recipe => recipe.RecipeId == id);
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
