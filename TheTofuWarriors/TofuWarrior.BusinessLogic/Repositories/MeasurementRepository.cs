using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.BusinessLogic.Interfaces;
using TofuWarrior.Model.ViewModels;
using TofuWarrior.Storage;

namespace TofuWarrior.BusinessLogic.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {

        private TheTofuWarriorsDBContext _db;
        public MeasurementRepository(TheTofuWarriorsDBContext db)
        {
            _db = db;
        }

        private ViewModelMeasurement ConvertToModel(MeasureUnit measure)
        {
            if (measure == null) return null;
            var model = new ViewModelMeasurement()
            {
                Description = measure.Description,
                Unit = measure.Unit,
                MeasureUnitId = measure.MeasureUnitId
            };
            return model;
        }

        public async Task<List<ViewModelMeasurement>> GetAllMeasurements()
        {
            var measurements = await _db.MeasureUnits.ToListAsync();
            return measurements.ConvertAll(ConvertToModel);
        }

        public async Task<ViewModelMeasurement> AddMeasurement(ViewModelMeasurement measure)
        {
            //TODO: Validation
            var newMeasure = new MeasureUnit()
            {
                Description = measure.Description,
                Unit = measure.Unit
            };
            _db.MeasureUnits.Add(newMeasure);
            await _db.SaveChangesAsync();

            return ConvertToModel(newMeasure);
        }

        public async Task<ViewModelMeasurement> GetMeasureById(int measureUnitId)
        {
            var measure = await (from m in _db.MeasureUnits where m.MeasureUnitId == measureUnitId select m).FirstAsync();
            return ConvertToModel(measure);
        }
    }
}
