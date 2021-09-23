using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic
{
    public interface IRepository<T> where T:TheTofuWarriorsDBContext
    {
        Task<List<T>> GetAllItemAsync();
        Task<List<T>> GetItemsByIdAsync(int[] id);
        Task<T> CreateRecipeAsync();

    }
}
