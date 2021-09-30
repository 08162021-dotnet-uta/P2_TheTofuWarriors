using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TofuWarrior.Storage;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using static TofuWarrior.BusinessLogic.Repositories.Mapper;

namespace TofuWarrior.BusinessLogic.Repositories
{
	public class UserRepository : IUserRepository
	{
		public TheTofuWarriorsDBContext _dbc;

		public UserRepository(TheTofuWarriorsDBContext dbc)
		{
			_dbc = dbc;
		}

		public async Task<List<ViewModelUser>> UserListAsync()
		{
			var users = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User]").ToListAsync();

			return users.ConvertAll(ConvertToModel);
		}

		public async Task<ViewModelUser> UserLoginAsync(string username, string password)
		{

			var user = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User] WHERE Username = {0} and Password = {1}", username, password).FirstOrDefaultAsync();

			return ConvertToModel(user);
		}

		public async Task RegisterAsync(ViewModelUser newUser)
		{

			var user = await _dbc.Database.ExecuteSqlRawAsync("INSERT INTO App.[User](FirstName,LastName,Email,Username,[Password]) VALUES ({0},{1},{2},{3},{4})", newUser.FirstName, newUser.LastName, newUser.Email, newUser.UserName, newUser.Password);
		}

		public async Task<ViewModelUser> FindUserAsync(string username)
		{
			var user = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User] WHERE Username = {0}", username).FirstOrDefaultAsync();

			return ConvertToModel(user);

		}

		public async Task<List<ViewModelRecipe>> GetUserRecipes(int userId)
		{
			var userRecipes = await (from u in _dbc.Users where u.UserId == userId select u.Recipes).FirstAsync();
			return userRecipes.ToList().ConvertAll(ConvertToModel);
		}

		public async Task<ViewModelUser> GetUserById(int userId)
		{
			var user = await (from u in _dbc.Users where u.UserId == userId select u).FirstAsync();
			return ConvertToModel(user);
		}

		//get all influencer's info based on userId




	}
}