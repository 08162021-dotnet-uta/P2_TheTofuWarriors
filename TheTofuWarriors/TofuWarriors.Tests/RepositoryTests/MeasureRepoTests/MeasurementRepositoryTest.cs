using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Repositories;
using TofuWarrior.Storage;
using TofuWarrior.Tests.RepositoryTests.DatabaseMock;
using Xunit;

namespace TofuWarrior.Tests.RepositoryTests.MeasureRepoTests
{
	[Collection("Measure Repository Tests")]
	public class MeasurementRepositoryTest
	{

		public static IEnumerable<object[]> GetData()
		{
			for (var i = 1; i <= 1000; i++)
			{
				yield return new object[] { i , $"tsp{i}", $"Teaspoon {i}"};
			}
		}


		[Theory]
		[MemberData(nameof(GetData))]
		public async Task Test_MeasureRepo(int id, string unit, string description)
		{
			// set up an in-memory version of TheTofuWarriorsDBContext
			using (var mockDbContext = new MockTofuWarriorsDB())
			{
				// Delete the database if it already exists
				mockDbContext.Database.EnsureDeleted();
				// Re-make the database
				mockDbContext.Database.EnsureCreated();

				var measureUnit = new MeasureUnit()
				{
					MeasureUnitId = id,
					Unit = unit,
					Description = description
				};
				mockDbContext.MeasureUnits.Add(measureUnit);
				mockDbContext.SaveChanges();

				var test_repo = new MeasurementRepository(mockDbContext);
				var measures = await test_repo.GetAllMeasurements();

				Assert.NotEmpty(measures);
				foreach (var measure in measures)
				{
					Assert.Equal(id, measure.MeasureUnitId);
					Assert.Equal(unit, measure.Unit);
					Assert.Equal(description, measure.Description);
				}

			}
		}
	}
}
