using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;
using ApiModel = TofuWarrior.BusinessLogic.Api;

namespace TofuWarrior.BusinessLogic.Repositories
{
	class ApiRecipeMapper
	{

		public static ViewModelRecipeIngredient ConvertToModel(ApiModel.Ingredient ingredient)
		{
			float q;
			float.TryParse(ingredient.quantity, out q);
			return new ViewModelRecipeIngredient()
			{
				IngredientId = 0,
				RecipeIngredientId = 0,
				Quantity = (int) q,
				IngredientName = ingredient.food,
				IngredientDescription = ingredient.text,
				MeasureUnitId = 0,
				MeasureUnit = ingredient.measure,
				MeasureDescription = ingredient.measure
			};
		}
		public static ViewModelRecipe ConvertToModel(ApiModel.Recipe apiModel)
		{
			if (apiModel == null)
				return null;

			return new ViewModelRecipe
			{
				Instructions = string.Join("\n", apiModel.ingredientLines),
				IsExternal = true,
				ApiKey = apiModel.uri,
				Name = apiModel.label,
				ImageUrl = apiModel.image,
				Ingredients = apiModel.ingredients.Select(ConvertToModel).ToList(),
				Tags = ParseTags(apiModel)
			};
		}

		public static List<ViewModelTag> ParseTags(ApiModel.Recipe recipe)
		{
			List<ViewModelTag> tags = new();
			foreach (var dietLabel in recipe.dietLabels)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = dietLabel,
					TagType = 1
				});
			}
			foreach (var healthLabel in recipe.healthLabels)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = healthLabel,
					TagType = 2
				});
			}
			foreach (var caution in recipe.cautions)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = caution,
					TagType = 3
				});
			}
			foreach (var type in recipe.cuisineType)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = type,
					TagType = 4
				});
			}
			foreach (var type in recipe.dishType)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = type,
					TagType = 5
				});
			}
			foreach (var type in recipe.mealType)
			{
				tags.Add(new ViewModelTag()
				{
					TagId = 0,
					Name = type,
					TagType = 6
				});
			}
			return tags;
		}

	}
}
