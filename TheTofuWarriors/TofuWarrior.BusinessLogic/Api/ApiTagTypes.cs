using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TofuWarrior.BusinessLogic.Api
{
	public static class ApiTagTypes
	{

		private static readonly Dictionary<int, (string labelType, List<string> validLabels)> tagTypes = new()
		{
			[1] = ("diet", new()
			{
				"balanced",
				"high-fiber",
				"high-protein",
				"low-carb",
				"low-fat",
				"low-sodium"
			}),
			[2] = ("health", new()
			{
				"alcohol-free",
				"celery-free",
				"crustacean-free",
				"dairy-free",
				"DASH",
				"egg-free",
				"fish-free",
				"fodmap-free",
				"gluten-free",
				"immuno-supportive",
				"keto-friendly",
				"kidney-friendly",
				"kosher",
				"low-fat-abs",
				"low-potassium",
				"low-sugar",
				"lupine-free",
				"Mediterranean",
				"mustard-free",
				"no-oil-added",
				"paleo",
				"peanut-free",
				"pescatarian",
				"pork-free",
				"red-meat-free",
				"sesame-free",
				"shellfish-free",
				"soy-free",
				"sugar-conscious",
				"tree-nut-free",
				"vegan",
				"vegetarian",
				"wheat-free"
			}),
			// TODO: this shouldn't be here, it's not part of the search api
			//[3] = ("cautions", new() { }),
			[4] = ("cuisineType", new()
			{
				"American",
				"Asian",
				"British",
				"Caribbean",
				"Central Europe",
				"Chinese",
				"Eastern Europe",
				"French",
				"Indian",
				"Italian",
				"Japanese",
				"Kosher",
				"Mediterranean",
				"Mexican",
				"Middle Eastern",
				"Nordic",
				"South American",
				"South East Asian"
			}),
			[5] = ("dishType", new()
			{
				"Biscuits and cookies",
				"Bread",
				"Cereals",
				"Condiments and sauces",
				"Desserts",
				"Drinks",
				"Main course",
				"Pancake",
				"Preps",
				"Preserve",
				"Salad",
				"Sandwiches",
				"Side dish",
				"Soup",
				"Starter",
				"Sweets"
			}),
			[6] = ("mealType", new()
			{
				"Breakfast",
				"Dinner",
				"Lunch",
				"Snack",
				"Teatime"
			}),
		};

		public static List<int> GetValidTypeIds()
		{
			return tagTypes.Keys.ToList();
			//return new() { 1, 2, 4, 5, 6 };
		}

		public static List<string> GetValidLabels(int typeId)
		{
			return tagTypes[typeId].validLabels;
		}

		public static bool IsValidLabel(int typeId, string label)
		{
			return tagTypes[typeId].validLabels.Contains(label);
		}

		public static string GetQueryParamForType(int typeId)
		{
			return tagTypes[typeId].labelType;
		}
	}
}
