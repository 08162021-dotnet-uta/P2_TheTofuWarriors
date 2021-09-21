using System;

namespace TheTofuWarrior.Model.ViewModels
{
  public class ViewModelRecipe
  {
    public int RecipeId { get; set; }
    public int CreatorUserId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public DateTime? CreationTime { get; set; }






  }
}
