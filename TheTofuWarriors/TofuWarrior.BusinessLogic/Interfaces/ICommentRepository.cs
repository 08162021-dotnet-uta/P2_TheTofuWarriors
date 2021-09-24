using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using TheTofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
  public interface ICommentRepository{
    //list all comments change to nameAsync
   Task<List<ViewModelComment>> ListCommentsAsync(int RecipeId);
   Task AddCommentAsync(ViewModelComment comment);
    // //fetch first 20 comment for each recipe and first 20 comment for EACH comment 
    // List<ViewModelComment> ListFirstTwentyComents(int RecipeId);
  }
  
}