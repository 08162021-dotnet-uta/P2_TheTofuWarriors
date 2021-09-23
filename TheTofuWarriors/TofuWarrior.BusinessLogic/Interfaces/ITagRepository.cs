using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
    public interface ITagRepository
    {
        Task<List<ViewModelTag>> GetAllTagsAsync();
        Task<ViewModelTag> GetTagByIdAsync(int tagId);
        Task<ViewModelTag> CreateTagAsync(ViewModelTag tag);
        Task<ViewModelTag> UpdateTagAsync(int tagId, ViewModelTag newTag);
    }
}
