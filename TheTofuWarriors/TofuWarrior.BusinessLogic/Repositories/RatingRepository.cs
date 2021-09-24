using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TofuWarrior.Storage;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace TofuWarrior.BusinessLogic
{
  public class RatingRepository : IRatingRepository
  {
    public TheTofuWarriorsDBContext _dbc;

    public RatingRepository(TheTofuWarriorsDBContext dbc)
    {
      _dbc = dbc;
    }

    private ViewModelRating ConvertToModel(Rating rating)
    {
      var modelRating = new ViewModelRating();
      modelRating.RatingId = rating.RatingId;
      modelRating.UserId = rating.UserId;
      modelRating.RecipeId = rating.RecipeId;
      modelRating.Score = rating.Score;

      return modelRating;
    }

    public async Task AddRatingAsync(ViewModelRating userRating)
    {
      var rating = await _dbc.Database.ExecuteSqlRawAsync("INSERT INTO App.Rating (UserID, RecipeId, Score) VALUES ({0},{1},{2})", userRating.UserId, userRating.RecipeId, userRating.Score);
    }

    public async Task<List<ViewModelRating>> RatingByScoreAsync(byte score)
    {
      var rating = await _dbc.Ratings.FromSqlRaw("SELECT * FROM App.Rating WHERE Score = {0}", score).ToListAsync();

      return rating.ConvertAll(this.ConvertToModel);
    }




  }
}