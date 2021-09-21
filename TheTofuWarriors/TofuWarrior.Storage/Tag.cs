using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class Tag
    {
        public Tag()
        {
            RecipeTags = new HashSet<RecipeTag>();
        }

        public int TagId { get; set; }
        public string Name { get; set; }
        public short? TagType { get; set; }

        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}
