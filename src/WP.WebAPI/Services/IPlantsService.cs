using System.Collections.Generic;
using System.Threading.Tasks;

using WP.WebAPI.Models;


namespace WP.WebAPI.Services {
    public interface IPlantsService {
        IEnumerable<PlantModel> GetPlants();
        PlantModel GetPlant(long plantId);
        bool EditPlant(long plantId, PlantModel plantModel);
        PlantModel AddPlant(PlantModel plantModel);
        PlantModel DeletePlant(PlantModel plantModel);
        bool PlantExists(long id);

    }
}