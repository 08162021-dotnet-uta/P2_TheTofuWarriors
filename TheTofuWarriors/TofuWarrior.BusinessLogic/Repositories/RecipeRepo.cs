using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class RecipeRepo: IRepository

    {
        private readonly TheTofuWarriorsDBContext _context;
        private readonly ILogger<RecipeRepo> _logger;
        public RecipeRepo(TheTofuWarriorsDBContext context, ILogger<RecipeRepo> logger)
        {
            _context = context;
            _logger = logger;
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

      
    }
}
