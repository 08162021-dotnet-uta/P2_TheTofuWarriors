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

		public async Task<ViewModelUser> RegisterAsync(ViewModelUser newUser)
		{
			var user = new User
			{
				FirstName = newUser.FirstName,
				LastName = newUser.LastName,
				Email = newUser.Email,
				Username = newUser.UserName,
				Password = newUser.Password
			};
			_dbc.Users.Add(user);
			await _dbc.SaveChangesAsync();
			return ConvertToModel(user);
		}


		public async Task<ViewModelUser> FindUserAsync(string username)
		{
			var user = await _dbc.Users.FromSqlRaw("SELECT * FROM App.[User] WHERE Username = {0}", username).FirstOrDefaultAsync();

			return ConvertToModel(user);

		}


		public async Task<ViewModelUser> GetUserById(int userId)
		{
			var user = await (from u in _dbc.Users where u.UserId == userId select u).FirstAsync();
			return ConvertToModel(user);
		}

		//get all influencer's info based on userId




	}
}