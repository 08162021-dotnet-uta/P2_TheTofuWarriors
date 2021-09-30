using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

using Microsoft.EntityFrameworkCore;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly TheTofuWarriorsDBContext _context;
        private readonly ILogger<FollowingRepository> _logger;

        public FollowingRepository(TheTofuWarriorsDBContext context, ILogger<FollowingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddFollowingAsync(ViewModelFollowing following)
        {
            _context.Followings.Add(new Following()
            {
                FollowerId = following.FollowerId,
                InfluencerId = following.InfluencerId
            });
                await _context.SaveChangesAsync();
        }

        public async Task UnFollowingAsync(ViewModelFollowing unfollow)
        {
            _context.Followings.Remove(new Following { FollowingId = unfollow.FollowingId });
            await _context.SaveChangesAsync();
        }
        //get all the following relationship of a user by usreId
        //get users' following relationship by userId
		public async Task<List<ViewModelFollowing>> GetUserFollowingById(int userId)
		{
           List<Following> results = await _context.Followings.Where(f=>f.FollowerId == userId).ToListAsync();
   
			return results.Select(f=> new ViewModelFollowing(){ 
                FollowerId=f.FollowerId,
                FollowingId=f.FollowingId,
                InfluencerId=f.InfluencerId
            }).ToList();
		}
    }
}
