using System.Collections.Generic;
using System.Threading.Tasks;

using WP.WebAPI.Models;

namespace WP.WebAPI.Services {
    public interface IPlantsService {
        Task<List<PlantModel>> GetPlantsAsync();
        IEnumerable<PlantModel> GetPlants();
        Task<PlantModel> GetPlantAsync(long plantId);
        PlantModel GetPlant(long plantId);
        Task<bool> EditPlantAsync(PlantModel plantModel);
        Task<PlantModel> AddPlantAsync(PlantModel plantModel);
        Task<PlantModel> DeletePlantAsync(long id);
        bool PlantExists(long id);

    }
}