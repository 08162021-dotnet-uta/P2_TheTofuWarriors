using System;
using System.Collections.Generic;

namespace TheTofuWarrior.Model.ViewModels
{

    public class ViewModelComment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }

        public int RecipeId { get; set; }
        public string CommentText { get; set; }
        public DateTime? CommentTime { get; set; }
        public int? PrevCommentId { get; set; }
        public List<ViewModelComment> SubComments {get;set;}



  }
}