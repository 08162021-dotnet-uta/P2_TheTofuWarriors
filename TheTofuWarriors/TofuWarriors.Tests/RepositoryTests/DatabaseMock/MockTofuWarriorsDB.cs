using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.Storage;

namespace TofuWarrior.Tests.RepositoryTests.DatabaseMock
{
	public class MockTofuWarriorsDB : TheTofuWarriorsDBContext
	{

		private static DbContextOptions<TheTofuWarriorsDBContext> _opts =
			new DbContextOptionsBuilder<TheTofuWarriorsDBContext>()
				.UseInMemoryDatabase("TheTofuWarriorsDB")
				.Options;
		public MockTofuWarriorsDB() : base(_opts)
		{
			
		}


		public void AddDefaultUsers()
		{
			//this.Users.Add()
		}

		public void AddDefaultMeasureUnits()
		{
		}
	}
}
