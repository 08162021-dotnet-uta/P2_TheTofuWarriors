using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class TagRepository : ITagRepository
    {
        private TheTofuWarriorsDBContext _db;
        public TagRepository(TheTofuWarriorsDBContext db) : base()
        {
            _db = db;
        }

        /// <summary>
        /// Convert from a database Tag object to a ViewModelTag object
        /// </summary>
        /// <param name="tag">Db object</param>
        /// <returns>ViewModelTag</returns>
        private ViewModelTag ConvertToModel(Tag tag)
        {
            if (tag == null) return null;
            var modelTag = new ViewModelTag();
            modelTag.Name = tag.Name;
            modelTag.TagId = tag.TagId;
            // TODO: this should match -- I think we need to change ViewModelTag.TagType to be *short* to match the DB (jon)
            modelTag.TagType = (byte) tag.TagType;
            return modelTag;
        }

        /// <summary>
        /// Get all tags from storage
        /// </summary>
        /// <returns>List containing all tags</returns>
        public async Task<List<ViewModelTag>> GetAllTagsAsync()
        {
            var tags = await _db.Tags.ToListAsync();
            return tags.ConvertAll(ConvertToModel);
        }

        private async Task<Tag> GetDBTagByIdAsync(int tagId)
        {
            return await (from t in _db.Tags where t.TagId == tagId select t).FirstAsync();
        }

        public async Task<ViewModelTag> GetTagByIdAsync(int tagId)
        {
            var tag = await (from t in _db.Tags where t.TagId == tagId select t).FirstAsync();
            return ConvertToModel(tag);
        }

        public async Task<ViewModelTag> CreateTagAsync(ViewModelTag tag)
        {
            // TODO: Add validation for name + TagType
            var newTag = new Tag();
            newTag.Name = tag.Name;
            newTag.TagType = tag.TagType;

            _db.Tags.Add(newTag);
            await _db.SaveChangesAsync();

            //await _db.Entry(newTag).ReloadAsync();
            return ConvertToModel(newTag);
        }

            // TODO: this doesn't really need a separate arg for tagID does it?
        public async Task<ViewModelTag> UpdateTagAsync(int tagId, ViewModelTag newTag)
        {
            var tag = await (from t in _db.Tags where t.TagId == tagId select t).FirstAsync();
            //TODO: validation
            tag.Name = newTag.Name;
            tag.TagType = newTag.TagType;
            _db.Tags.Update(tag);
            await _db.SaveChangesAsync();

            return ConvertToModel(tag);
        }

        public async Task<ViewModelRecipe> AddTagToRecipe(int tagId, int recipeId)
        {
            var tag = await _db.Tags.
        }
    }
}
