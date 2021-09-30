using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
    public interface IFollowingRepository
    {
        //add following relationship
        Task AddFollowingAsync(ViewModelFollowing following);

        //remove following relationship
        Task UnFollowingAsync(ViewModelFollowing unfollow);
        Task<List<ViewModelFollowing>> GetUserFollowingById(int userId);



    }
}
