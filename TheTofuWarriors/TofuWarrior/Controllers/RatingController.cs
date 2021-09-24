using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class RatingController : ControllerBase
  {

    private IRatingRepository _rating;
    public RatingController(IRatingRepository rating) : base()
    {
      _rating = rating;
    }

    [HttpPost("addrating")]
    public async Task AddRating(ViewModelRating userRating)
    {
      await _rating.AddRatingAsync(userRating);

    }

    [HttpGet("rating/{score}")]
    public async Task<List<ViewModelRating>> RatingByScore(byte score)
    {
      var rating = await _rating.RatingByScoreAsync(score);

      return rating;
    }

  }

}