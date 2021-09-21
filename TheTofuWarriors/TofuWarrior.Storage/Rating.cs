using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public byte Score { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
