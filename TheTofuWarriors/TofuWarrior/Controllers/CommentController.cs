using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        [HttpGet("{recipeId}")]
        public async Task<List<ViewModelComment>> Get(int recipeId)
        {
            return await _commentRepository.ListCommentsAsync(recipeId);



        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] ViewModelComment newComment)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _commentRepository.AddCommentAsync(newComment);
            return Ok(new { Success = true });

        }
    }
}
