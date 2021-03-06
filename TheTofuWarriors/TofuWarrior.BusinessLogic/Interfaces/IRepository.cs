using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Interfaces
{
    public interface IRepository
    {
        Task<List<ViewModelRecipe>> GetAllItemAsync();
        Task<ViewModelRecipe> GetItemsByIdAsync(int id);
        Task<Recipe> DeleteItemAsync(ViewModelRecipe item);
        Task<Recipe> CreateItemAsync(ViewModelRecipe item);
		Task<List<ViewModelRecipe>> SearchRecipes(List<string> ingredientNames, List<ViewModelTag> tags);
		Task<ViewModelRecipe> SaveUserRecipe(ViewModelRecipe recipe, ViewModelUser user);
        Task<List<ViewModelRecipe>> GetUserRecipes(int userId);
    }
}
