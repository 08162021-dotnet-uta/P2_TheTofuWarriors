using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Repositories;
using TofuWarrior.Storage;
using TofuWarrior.Tests.RepositoryTests.DatabaseMock;
using Xunit;

namespace TofuWarrior.Tests.RepositoryTests.MeasureRepoTests
{
	[Collection("Repository Tests")]
	public class RecipeRepoTest
	{
        public static IEnumerable<object[]> GetData()
		{
			for (var i = 1; i <= 1000; i++)
			{
				yield return new object[] { i, i, $"Jamican Curry Goat{i}", $"1.Curry Your Goats!{i}", DateTime.Today };
			}
		}

		[Theory]
		[MemberData(nameof(GetData))]
		public async Task Test_RecipeRepo(int id, int creatorId, string name, string instructions, DateTime recipeDate)
		{
			
			// set up an in-memory version of TheTofuWarriorsDBContext
			using (var mockDbContext = new MockTofuWarriorsDB())
			{
				// Delete the database if it already exists
				mockDbContext.Database.EnsureDeleted();
				// Re-make the database
				mockDbContext.Database.EnsureCreated();

				var recipe = new Recipe()
				{
					RecipeId = id,
					CreatorUserId = creatorId,
					Name = name,
					Instructions = instructions,
					CreationTime = recipeDate
				};
				mockDbContext.Recipes.Add(recipe);
				mockDbContext.SaveChanges();

				// TODO: set up a null logger and a mocked htttpClient
				var recipe_repotest = new RecipeRepo(mockDbContext, null, null); 
				var recipes = await recipe_repotest.GetAllItemAsync();

				Assert.NotEmpty(recipes);
				foreach (var rec in recipes)
				{
					Assert.Equal(id, recipe.RecipeId);
					Assert.Equal(creatorId, recipe.CreatorUserId);
					Assert.Equal(name, recipe.Name);
					Assert.Equal(instructions, recipe.Instructions);
					Assert.Equal(creatorId, recipe.CreatorUserId);
				}

			}
		}
	}
}
