using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public int MeasureUnitId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
