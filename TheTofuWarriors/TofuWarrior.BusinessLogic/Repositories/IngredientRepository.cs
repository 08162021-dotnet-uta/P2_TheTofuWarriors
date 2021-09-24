using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private TheTofuWarriorsDBContext _db;
        public IngredientRepository(TheTofuWarriorsDBContext db)
        {
            _db = db;
        }

        private ViewModelIngredient ConvertToModel(Ingredient ingredient)
        {
            if (ingredient == null) return null;

            var model = new ViewModelIngredient()
            {
                Name = ingredient.Name,
                IngredientId = ingredient.IngredientId,
                Description = ingredient.Description
            };
            return model;
        }

        private ViewModelRecipe ConvertToModel(Recipe r)
        {
            if (r == null) return null;
            var recipe = new ViewModelRecipe();
            recipe.RecipeId = r.RecipeId;
            recipe.Instructions = r.Instructions;
            recipe.CreatorUserId = r.CreatorUserId;
            recipe.CreationTime = r.CreationTime;
            recipe.Name = r.Name;
            recipe.Ingredients = (from ri in r.RecipeIngredients select ConvertToModel(ri.Ingredient)).ToList();

            return recipe;
        }


        public async Task<List<ViewModelIngredient>> GetAllIngredients()
        {
            var ingredients = await _db.Ingredients.ToListAsync();
            return ingredients.ConvertAll(ConvertToModel);
        }

        public async Task<ViewModelIngredient> AddIngredient(ViewModelIngredient data)
        {
            var ingredient = new Ingredient()
            {
                Name = data.Name,
                Description = data.Description
            };
            _db.Ingredients.Add(ingredient);
            await _db.SaveChangesAsync();

            return ConvertToModel(ingredient);
        }

        public async Task<ViewModelIngredient> GetIngredientById(int ingredientId)
        {
            var ingredient = await (from i in _db.Ingredients where i.IngredientId == ingredientId select i).FirstAsync();
            return ConvertToModel(ingredient);
        }

        public async Task<ViewModelRecipe> AddIngredientToRecipe(ViewModelRecipeIngredient data)
        {
            // TODO: validation
            var ingredient = await (from i in _db.Ingredients where i.IngredientId == data.IngredientId select i).FirstAsync();
            var recipe = await (from r in _db.Recipes where r.RecipeId == data.RecipeId select r).Include(r => r.RecipeIngredients).FirstAsync();

            var link = new RecipeIngredient()
            {
                Quantity = data.Quantity,
                RecipeId = data.RecipeId,
                IngredientId = data.IngredientId,
                MeasureUnitId = data.MeasureUnitId
            };

            _db.RecipeIngredients.Add(link);
            await _db.SaveChangesAsync();

            // TODO: Reload recipe object?
            return ConvertToModel(recipe);
        }

        public async Task<ViewModelRecipe> RemoveIngredientFromRecipe(ViewModelRecipeIngredient data)
        {
            var ingredient = await (from i in _db.Ingredients where i.IngredientId == data.IngredientId select i).FirstAsync();
            var recipe = await (from r in _db.Recipes where r.RecipeId == data.RecipeId select r).Include(r => r.RecipeIngredients).FirstAsync();
            var link = await (from ri in _db.RecipeIngredients where ri.RecipeIngredientId == data.RecipeIngredientId select ri).FirstAsync();

            _db.RecipeIngredients.Remove(link);
            await _db.SaveChangesAsync();

            // TODO: Reload recipe?
            return ConvertToModel(recipe);
        }

        public async Task<ViewModelRecipe> UpdateRecipeIngredient(ViewModelRecipeIngredient data)
        {
            var ingredient = await (from i in _db.Ingredients where i.IngredientId == data.IngredientId select i).FirstAsync();
            var recipe = await (from r in _db.Recipes where r.RecipeId == data.RecipeId select r).Include(r => r.RecipeIngredients).FirstAsync();
            var link = await (from ri in _db.RecipeIngredients where ri.RecipeIngredientId == data.RecipeIngredientId select ri).FirstAsync();

            link.Quantity = data.Quantity;
            link.MeasureUnitId = data.MeasureUnitId;
            await _db.SaveChangesAsync();

            // TODO: reload recipe?
            return ConvertToModel(recipe);
        }
    }
}
