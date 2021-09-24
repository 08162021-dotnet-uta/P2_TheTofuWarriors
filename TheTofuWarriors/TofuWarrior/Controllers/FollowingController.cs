using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Model.ViewModels;

namespace TofuWarrior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FollowingController : Controller
    {

        private readonly IFollowingRepository _followingRepository;

        public FollowingController(IFollowingRepository followingRepository)
        {
            _followingRepository = followingRepository;
        }
        //
        [HttpPost("follow")]
        public async Task<ActionResult> Add([FromBody] ViewModelFollowing following)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _followingRepository.AddFollowingAsync(following);
            return Ok(new { Success = true });

        }

        //
        [HttpDelete("unfollow")]
        public async Task<ActionResult> Unfollow([FromBody] ViewModelFollowing unfollow)
        {
            await _followingRepository.UnFollowingAsync(unfollow);
            return Ok(new { Success = true });
        }

    }
}
