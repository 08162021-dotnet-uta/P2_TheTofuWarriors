using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TofuWarrior.Storage;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace TofuWarrior.BusinessLogic.Repositories
{
  public class UserRepository : IUserRepository
  {
    public TheTofuWarriorsDBContext _dbc;

    public UserRepository(TheTofuWarriorsDBContext dbc)
    {
      _dbc = dbc;
    }

    private ViewModelUser ConvertToModel(User user)
    {
      var modelUser = new ViewModelUser();
      modelUser.UserId = user.UserId;
      modelUser.FirstName = user.FirstName;
      modelUser.LastName = user.LastName;
      modelUser.Email = user.Email;
      modelUser.UserName = user.Username;
      modelUser.Password = user.Password;

      return modelUser;
    }

    public async Task<List<ViewModelUser>> UserListAsync()
    {
      var users = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User]").ToListAsync();

      return users.ConvertAll(this.ConvertToModel);
    }

    public async Task<ViewModelUser> UserLoginAsync(string username, string password)
    {

      var user = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User] WHERE Username = {0} and Password = {1}", username, password).FirstOrDefaultAsync();

      return this.ConvertToModel(user);
    }

    public async Task RegisterAsync(ViewModelUser newUser)
    {

      var user = await _dbc.Database.ExecuteSqlRawAsync("INSERT INTO App.[User](FirstName,LastName,Email,Username,[Password]) VALUES ({0},{1},{2},{3},{4})", newUser.FirstName, newUser.LastName, newUser.Email, newUser.UserName, newUser.Password);
    }

    public async Task<ViewModelUser> FindUserAsync(string username)
    {
      var user = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User] WHERE Username = {0}", username).FirstOrDefaultAsync();

      return this.ConvertToModel(user);

    }



  }
}