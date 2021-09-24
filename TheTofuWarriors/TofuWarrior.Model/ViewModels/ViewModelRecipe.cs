using System;
using System.Collections.Generic;

namespace TheTofuWarrior.Model.ViewModels
{
  public class ViewModelRecipe
  {
    public int RecipeId { get; set; }
    public int CreatorUserId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public DateTime? CreationTime { get; set; }


    public List<ViewModelTag> Tags { get; set; }
    public List<ViewModelIngredient> Ingredients { get; set; }


  }
}
