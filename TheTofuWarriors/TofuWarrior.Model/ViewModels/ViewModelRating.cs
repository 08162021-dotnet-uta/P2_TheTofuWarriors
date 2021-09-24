using System;
namespace TheTofuWarrior.Model.ViewModels
{
  public class ViewModelRating
  {
    public int RatingId { get; set; }
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public byte Score { get; set; }

  }
}