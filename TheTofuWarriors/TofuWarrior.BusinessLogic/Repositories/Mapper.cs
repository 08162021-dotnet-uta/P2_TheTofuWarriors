using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
	class Mapper
	{

		public static ViewModelUser ConvertToModel(User user)
		{
			if (user == null) return null;
			var modelUser = new ViewModelUser();
			modelUser.UserId = user.UserId;
			modelUser.FirstName = user.FirstName;
			modelUser.LastName = user.LastName;
			modelUser.Email = user.Email;
			modelUser.UserName = user.Username;
			modelUser.Password = user.Password;

			return modelUser;
		}

		public static ViewModelTag ConvertToModel(Tag tag)
		{
			if (tag == null) return null;
			var modelTag = new ViewModelTag()
			{
				Name = tag.Name,
				TagId = tag.TagId,
				TagType = tag.TagType
			};
			return modelTag;
		}

		public static ViewModelRating ConvertToModel(Rating rating)
		{
			if (rating == null) return null;
			var modelRating = new ViewModelRating();
			modelRating.RatingId = rating.RatingId;
			modelRating.UserId = rating.UserId;
			modelRating.RecipeId = rating.RecipeId;
			modelRating.Score = rating.Score;

			return modelRating;
		}


		public static ViewModelMeasurement ConvertToModel(MeasureUnit measure)
		{
			if (measure == null) return null;
			var model = new ViewModelMeasurement()
			{
				Description = measure.Description,
				Unit = measure.Unit,
				MeasureUnitId = measure.MeasureUnitId
			};
			return model;
		}

		/// <summary>
		/// Convert from a database Tag object to a ViewModelTag object
		/// </summary>
		/// <param name="tag">Db object</param>
		/// <returns>ViewModelTag</returns>
		public static ViewModelRecipe ConvertToModel(Recipe r)
		{
			if (r == null) return null;
			var recipe = new ViewModelRecipe();
			recipe.RecipeId = r.RecipeId;
			recipe.Instructions = r.Instructions;
			recipe.CreatorUserId = r.CreatorUserId;
			recipe.Creator = ConvertToModel(r.CreatorUser);
			recipe.CreationTime = r.CreationTime;
			recipe.Name = r.Name;
			recipe.Ingredients = (from ri in r.RecipeIngredients select ConvertToModel(ri)).ToList();
			recipe.Tags = (from rt in r.RecipeTags select ConvertToModel(rt.Tag)).ToList();

			return recipe;
		}

		public static ViewModelRecipeIngredient ConvertToModel(RecipeIngredient recipeIngredient)
		{
			if (recipeIngredient == null) return null;
			var result = new ViewModelRecipeIngredient()
			{
				RecipeIngredientId = recipeIngredient.RecipeIngredientId,
				IngredientId = recipeIngredient.IngredientId,
				Quantity = recipeIngredient.Quantity,
				IngredientName = recipeIngredient.Ingredient?.Name,
				IngredientDescription = recipeIngredient.Ingredient?.Description,
				MeasureUnitId = recipeIngredient.MeasureUnitId,
				MeasureUnit = ConvertToModel(recipeIngredient.MeasureUnit)
			};
			return result;
		}

		public static ViewModelIngredient ConvertToModel(Ingredient ingredient)
		{
			if (ingredient == null) return null;

			var model = new ViewModelIngredient()
			{
				IngredientName = ingredient.Name,
				IngredientId = ingredient.IngredientId,
				IngredientDescription = ingredient.Description
			};
			return model;
		}



		//Converts Model Recipe to ViewModel Recipe for client to interact with
		public static ViewModelRecipe RecipeToViewModelRecipe(Recipe r)
		{
			if (r == null) return null;
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
			if (r1 == null) return null;
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
