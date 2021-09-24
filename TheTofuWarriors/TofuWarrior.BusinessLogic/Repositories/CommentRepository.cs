using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TofuWarrior.Storage;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace TofuWarrior.BusinessLogic
{
   public class CommentRepository: ICommentRepository
    {
        private readonly TheTofuWarriorsDBContext _context ;
        private readonly ILogger<CommentRepository> _logger;

        public CommentRepository(TheTofuWarriorsDBContext context, ILogger<CommentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddCommentAsync(ViewModelComment comment)
        {
            _logger.LogInformation("HELLO");
            var newComment = new Comment()
            {
                UserId = comment.UserId,
                RecipeId = comment.RecipeId,
                CommentText = comment.CommentText,
                CommentTime = DateTime.Now,
                PrevCommentId = comment.PrevCommentId
            };
            _context.Comments.Add(newComment);
          await  _context.SaveChangesAsync();
        }
        //public List<ViewModelComment> ConvertToModel(IEnumerable<Comment> dbComments)
        //{
        //  return  dbComments.Select(c => new ViewModelComment()
        //    {
        //        CommentId = c.CommentId,
        //        CommentText = c.CommentText,
        //        PrevCommentId = c.PrevCommentId,
        //        UserId = c.UserId,
        //        RecipeId = c.RecipeId,
        //        CommnetTime = c.CommentTime,
        //        SubComments = ConvertToModel(c.InversePrevComment)
        //    }).ToList();
        //}
        public async Task<List<ViewModelComment>> ListCommentsAsync(int recipeId)
        {
            //var allComments= await  _context.Comments.Where(c => c.RecipeId == recipeId).Include(c => c.PrevComment).ToListAsync();

            //List of comment and each comment is going to have a .inverPrevcoment which is a list of subcomments
            //  List<ViewModelComment> results = new List<ViewModelComment>();
            //var Comments = await _context.Comments.Where(c => c.RecipeId == recipeId && c.PrevCommentId==null ).Include(c => c.InversePrevComment).ToListAsync();

            //  return ConvertToModel(Comments);
            List<Comment> allRelatedComments = await _context.Comments.Where(c => c.RecipeId == recipeId).ToListAsync();
            Dictionary<int, ViewModelComment> viewModelLookup = new Dictionary<int, ViewModelComment>();
            List<ViewModelComment> results = new List<ViewModelComment>();

            foreach (var comment in allRelatedComments)
            {
                ViewModelComment newCommentModel = new ViewModelComment
                {
                    CommentId = comment.CommentId,
                    CommentText = comment.CommentText,
                    PrevCommentId = comment.PrevCommentId,
                    RecipeId = comment.RecipeId,
                    UserId = comment.UserId,
                    SubComments = new List<ViewModelComment>(),
                };

                viewModelLookup.Add(comment.CommentId, newCommentModel);

                if (comment.PrevCommentId == null)
                    results.Add(newCommentModel);
            }

            foreach (var comment in allRelatedComments)
            {
                if (comment.PrevCommentId != null)
                {
                    viewModelLookup[comment.PrevCommentId.Value].SubComments.Add(viewModelLookup[comment.CommentId]);
                }
            }
            return results;
        }
    }
}
