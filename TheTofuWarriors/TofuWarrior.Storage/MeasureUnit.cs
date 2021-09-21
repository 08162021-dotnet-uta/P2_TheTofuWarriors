using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class MeasureUnit
    {
        public MeasureUnit()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int MeasureUnitId { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
