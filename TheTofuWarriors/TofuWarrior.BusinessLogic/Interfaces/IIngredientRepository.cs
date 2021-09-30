using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
    public interface IIngredientRepository
    {
		Task<List<ViewModelIngredient>> GetAllIngredients();
        Task<ViewModelIngredient> AddIngredient(ViewModelIngredient data);
        Task<ViewModelIngredient> GetIngredientById(int ingredientId);
        Task<ViewModelRecipe> AddIngredientToRecipe(ViewModelRecipeIngredient data);
        Task<ViewModelRecipe> RemoveIngredientFromRecipe(ViewModelRecipeIngredient data);
        Task<ViewModelRecipe> UpdateRecipeIngredient(ViewModelRecipeIngredient data);
    }
}
