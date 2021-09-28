using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;
using ApiRecipe = TofuWarrior.BusinessLogic.Api.Recipe;

namespace TofuWarrior.BusinessLogic.Repositories
{
	class ApiRecipeMapper
	{
		public static ViewModelRecipe ConvertToModel(ApiRecipe apiModel)
		{
			if (apiModel == null)
				return null;

			return new ViewModelRecipe {
				Instructions = string.Join("\n", apiModel.ingredientLines),
				IsExternal = true,
				Name = apiModel.label,
				ImageUrl = apiModel.image,
				Ingredients = apiModel.ingredients.Select(i =>
					new ViewModelIngredient {
						Description = i.text
					}
				).ToList()
			};
		}

	}
}
