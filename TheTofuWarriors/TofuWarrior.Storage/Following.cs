using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class Following
    {
        public int FollowingId { get; set; }
        public int FollowerId { get; set; }
        public int InfluencerId { get; set; }

        public virtual User Follower { get; set; }
        public virtual User Influencer { get; set; }
    }
}
