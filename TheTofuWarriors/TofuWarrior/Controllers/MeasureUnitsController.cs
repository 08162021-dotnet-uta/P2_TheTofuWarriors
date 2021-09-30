using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Model.ViewModels;

namespace TofuWarrior.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MeasureUnitsController : ControllerBase
	{
		private IMeasurementRepository _measures;
		public MeasureUnitsController(IMeasurementRepository measures)
		{
			_measures = measures;
		}

		[HttpGet]
		public async Task<List<ViewModelMeasurement>> getMeasures()
		{
			return await _measures.GetAllMeasurements();
		}
	}
}
