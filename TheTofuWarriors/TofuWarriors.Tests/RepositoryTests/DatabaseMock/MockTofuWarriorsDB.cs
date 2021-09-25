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

		private static DbContextOptions<TheTofuWarriorsDBContext> GetOptions() {
			var opts = new DbContextOptionsBuilder<TheTofuWarriorsDBContext>()
				.UseInMemoryDatabase("TheTofuWarriorsDB")
				.Options;
			return opts;
		}
		public MockTofuWarriorsDB() : base(GetOptions())
		{
			
		}


		public void AddDefaultUsers()
		{
			//this.Users.Add()
		}

		public void AddDefaultMeasureUnits()
		{
			MeasureUnits.Add(new MeasureUnit()
);
		}
	}
}
