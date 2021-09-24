using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagRepository _tags;
        public TagController(ITagRepository tags) : base()
        {
            _tags = tags;
        }

        [HttpGet]
        public async Task<List<ViewModelTag>> GetTagsAsync()
        {
            var tags = await _tags.GetAllTagsAsync();
            return tags;
        }

        [HttpGet("{id}")]
        public async Task<ViewModelTag> GetTagByIDAsync(int id)
        {
            var tag = await _tags.GetTagByIdAsync(id);
            return tag;
        }

        [HttpPost("add")]
        public async Task<ViewModelTag> AddTagAsync([FromBody] ViewModelTag tag)
        {
            // TODO: Validation on tag info
            var created = await _tags.CreateTagAsync(tag);
            return created;
        }

        [HttpPost("{id}")]
        public async Task<ViewModelTag> UpdateTag([FromBody] ViewModelTag tag)
        {
            // TODO: validation
            var updated = await _tags.UpdateTagAsync(tag.TagId, tag);
            return updated;
        }

    }
}
