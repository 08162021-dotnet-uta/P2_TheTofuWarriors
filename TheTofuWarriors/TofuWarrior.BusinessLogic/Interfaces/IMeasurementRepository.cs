using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TofuWarrior.Model.ViewModels;

namespace TofuWarrior.BusinessLogic.Interfaces
{
    public interface IMeasurementRepository
    {
        Task<ViewModelMeasurement> GetMeasureById(int measureUnitId);
        Task<ViewModelMeasurement> AddMeasurement(ViewModelMeasurement measure);
        Task<List<ViewModelMeasurement>> GetAllMeasurements();
    }
}
