using System.Collections.Generic;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
  public interface IUserRepository
  {
    Task<List<ViewModelUser>> UserListAsync();
    Task<ViewModelUser> UserLoginAsync(string username, string password);

    Task RegisterAsync(ViewModelUser newUser);

    Task<ViewModelUser> FindUserAsync(string username);

  }
}