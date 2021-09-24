using System.Collections.Generic;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
  public interface IRatingRepository
  {
    Task AddRatingAsync(ViewModelRating userRating);

    Task<List<ViewModelRating>> RatingByScoreAsync(byte score);

  }
}