using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
    class Mapper
    {
        //Converts Model Recipe to ViewModel Recipe for client to interact with
        public static ViewModelRecipe RecipeToViewModelRecipe(Recipe r)
        {
            ViewModelRecipe r1 = new ViewModelRecipe();
            r1.RecipeId = r.RecipeId;
            r1.Name = r.Name;
            r1.CreatorUserId = r.CreatorUserId;
            r1.Instructions = r.Instructions;
            r1.CreationTime = r.CreationTime;

            return r1;

        }
        public static Recipe ViewModelRecipeToRecipe(ViewModelRecipe r1)
        {
           Recipe r = new Recipe();
            r.RecipeId = r1.RecipeId;
            r.Name = r1.Name;
            r.CreatorUserId = r1.CreatorUserId;
            r.Instructions = r1.Instructions;
            r.CreationTime = (DateTime)r1.CreationTime;

            return r;

        }

    }
}
