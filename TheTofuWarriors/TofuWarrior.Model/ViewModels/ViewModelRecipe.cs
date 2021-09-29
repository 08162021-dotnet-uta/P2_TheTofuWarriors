using System;
using System.Collections.Generic;
using TofuWarrior.Model.ViewModels;

namespace TheTofuWarrior.Model.ViewModels
{
  public class ViewModelRecipe
  {
    public int RecipeId { get; set; }
    public int CreatorUserId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public DateTime? CreationTime { get; set; }
    public bool IsExternal { get; set; }
    public string ImageUrl { get; set; }

	public string ApiKey { get; set; }


    public List<ViewModelTag> Tags { get; set; }
    public List<ViewModelRecipeIngredient> Ingredients { get; set; }


  }
}
