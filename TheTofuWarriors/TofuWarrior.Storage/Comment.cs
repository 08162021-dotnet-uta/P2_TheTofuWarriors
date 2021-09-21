using System;
using System.Collections.Generic;

#nullable disable

namespace TofuWarrior.Storage
{
    public partial class Comment
    {
        public Comment()
        {
            InversePrevComment = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public int? PrevCommentId { get; set; }

        public virtual Comment PrevComment { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> InversePrevComment { get; set; }
    }
}
