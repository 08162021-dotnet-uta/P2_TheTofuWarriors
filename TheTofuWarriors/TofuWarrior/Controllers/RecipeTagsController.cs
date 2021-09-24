using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{
    [Route("recipe/{recipeId}/tags")]
    [ApiController]
    public class RecipeTagsController : ControllerBase
    {
        [FromRoute(Name ="recipeId")]
        public int RecipeId { get; set; }

        private ITagRepository _tags;
        //private IRecipeRepository _recipes;
        public RecipeTagsController(ITagRepository tags) : base()
        {
            _tags = tags;
        }

        [HttpGet]
        public async Task<List<ViewModelTag>> GetTagsForRecipe()
        {
            //_tags.AddTagToRecipe(recipe.RecipeId, )
            return await _tags.GetTagsForRecipeAsync(RecipeId);

        }

        [HttpPost("add")]
        // TODO: Consider just using tagId here
        public async Task<ViewModelRecipe> AddTagToRecipe(ViewModelTag tag)
        {
            var recipe = await _tags.AddTagToRecipeAsync(RecipeId, tag.TagId);
            return recipe;
        }
    }
}
