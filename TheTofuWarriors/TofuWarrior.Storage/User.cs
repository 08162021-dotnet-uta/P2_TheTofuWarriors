using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            FollowingFollowers = new HashSet<Following>();
            FollowingInfluencers = new HashSet<Following>();
            Ratings = new HashSet<Rating>();
            Recipes = new HashSet<Recipe>();
            UserRecipes = new HashSet<UserRecipe>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Following> FollowingFollowers { get; set; }
        public virtual ICollection<Following> FollowingInfluencers { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<UserRecipe> UserRecipes { get; set; }
    }
}
