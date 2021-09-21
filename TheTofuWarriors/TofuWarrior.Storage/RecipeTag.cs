using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class RecipeTag
    {
        public int RecipeTagId { get; set; }
        public int TagId { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
