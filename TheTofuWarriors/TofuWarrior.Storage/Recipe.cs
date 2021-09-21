using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class Recipe
    {
        public Recipe()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
            RecipeTags = new HashSet<RecipeTag>();
            UserRecipes = new HashSet<UserRecipe>();
        }

        public int RecipeId { get; set; }
        public int CreatorUserId { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
        public virtual ICollection<UserRecipe> UserRecipes { get; set; }
    }
}
