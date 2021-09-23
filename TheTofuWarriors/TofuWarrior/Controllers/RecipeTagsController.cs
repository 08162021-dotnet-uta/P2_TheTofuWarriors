using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TofuWarrior.Controllers
{
    [Route("recipe/{recipeId}/tags")]
    [ApiController]
    public class RecipeTagsController : ControllerBase
    {
        public RecipeTagsController() : base()
        {

        }
    }
}
