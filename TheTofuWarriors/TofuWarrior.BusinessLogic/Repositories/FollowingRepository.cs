using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic
{
    public class FollowingRepository:IFollowingRepository
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
    }
}
