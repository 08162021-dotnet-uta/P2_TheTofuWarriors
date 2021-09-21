using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class UserRecipe
    {
        public int UserRecipeId { get; set; }
        public int UserId { get; set; }
        public int? RecipeId { get; set; }
        public int? ApiRecipeKey { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
