using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TofuWarrior.Model.ViewModels
{
    public class ViewModelRecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public int MeasureUnitId { get; set; }

    }
}
