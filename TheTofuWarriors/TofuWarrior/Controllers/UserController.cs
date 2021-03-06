using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Interfaces;

namespace TofuWarrior.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private IUserRepository _user;
		private IRepository _recipeRepo;
		
		public UserController(IUserRepository user, IRepository recipeRepo) : base()
		{
			_user = user;
			_recipeRepo = recipeRepo;
		}

		[HttpGet("userlist")]
		public async Task<List<ViewModelUser>> UserListAsync()
		{
			var user = await _user.UserListAsync();

			return user;
		}

		[HttpGet("finduser/{userName}")]
		public async Task<ViewModelUser> Username(string userName)
		{
			// var username = userInfo.UserName;
			var user = await _user.FindUserAsync(userName);

			return user;
		}

		[HttpPost("login")]
		public async Task<ViewModelUser> Login(ViewModelUser userInfo)
		{
			var username = userInfo.UserName;
			var password = userInfo.Password;

			var user = await _user.UserLoginAsync(username, password);

			return user;

		}

		[HttpPost("register")]

		public async Task<ViewModelUser> Register(ViewModelUser newUser)
		{
			return await _user.RegisterAsync(newUser);

		}


		[HttpGet("{userId}/recipes")]
		public async Task<List<ViewModelRecipe>> GetUserRecipes(int userId)
		{
			var recipes = await _recipeRepo.GetUserRecipes(userId);
			return recipes;
		}


		[HttpGet("{userId}")]
		public async Task<ViewModelUser> GetUserById(int userId)
		{
			var user = await _user.GetUserById(userId);
			return user;
		}

	}
}