using System.Collections.Generic;
using System.Threading.Tasks;
using TheTofuWarrior.Model.ViewModels;
using TofuWarrior.BusinessLogic.Repositories;
using TofuWarrior.Storage;
using TofuWarrior.Tests.RepositoryTests.DatabaseMock;
using Xunit;

namespace TofuWarrior.Tests.RepositoryTests.UserRepoTests
{
	[Collection("Measure Repository Tests")]
	public class UserTest
	{
		[Fact]
		public async Task Test_UserRepo()
		{
			using (var mockDBContext = new MockTofuWarriorsDB())
			{
				// ARRANGE
				mockDBContext.Database.EnsureDeleted();
				mockDBContext.Database.EnsureCreated();

				User user1 = new User()
				{
					FirstName = "Test",
					LastName = "User",
					Email = "testuser@gmail.com",
					Username = "testuser",
					Password = "pass1"
				};

				User user2 = new User()
				{
					FirstName = "User",
					LastName = "Test",
					Email = "usertest@gmail.com",
					Username = "usertest",
					Password = "pass2"
				};

				mockDBContext.Users.Add(user1);
				mockDBContext.Users.Add(user2);
				mockDBContext.SaveChanges();

				UserRepository userRepo = new UserRepository(mockDBContext);

				// ACT
				List<ViewModelUser> users = await userRepo.UserListAsync();

				// ASSERT
				Assert.Equal(2, users.Count);
				Assert.True(users.Count == 2);
				Assert.True(users[0].FirstName == "Test");
				Assert.Contains("er", users[1].FirstName);
			}

		}

		[Fact]
		public async Task CheckUserLogin()
		{
			using (var mockDBContext = new MockTofuWarriorsDB())
			{
				// ARRANGE

				mockDBContext.Database.EnsureDeleted();
				mockDBContext.Database.EnsureCreated();

				User user1 = new User()
				{
					FirstName = "Test",
					LastName = "User",
					Email = "testuser@gmail.com",
					Username = "testuser",
					Password = "pass1"
				};

				User user2 = new User()
				{
					FirstName = "User",
					LastName = "Test",
					Email = "usertest@gmail.com",
					Username = "usertest",
					Password = "pass2"
				};

				mockDBContext.Users.Add(user1);
				mockDBContext.Users.Add(user2);
				mockDBContext.SaveChanges();

				UserRepository userRepo = new UserRepository(mockDBContext);

				// ACT
				ViewModelUser users = await userRepo.UserLoginAsync(user1.Username, user1.Password);

				// ASSERT
				Assert.True(users.FirstName == "Test" && users.LastName == "User");
				Assert.True(users.UserName == "testuser");
				Assert.True(users.Email == "testuser@gmail.com");
			}
		}



	}//EoC

}//EoN
