using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WP.WebAPI.Models;

namespace WP.WebAPI.Services {
    public class MockedPlantsService : IPlantsService {
        private List<PlantModel> _plants;
        public MockedPlantsService() {
            _plants = new List<PlantModel>() {
                new PlantModel() { Id = 12, FriendlyName = "Cool Plant", ScientificName = "Some cool science name"},
                new PlantModel() { Id = 24, FriendlyName = "Another Plant", ScientificName = "Sci Ano Plant" },
                new PlantModel() { Id = 69, FriendlyName = "Sexy Plant", ScientificName = "SexyTime-mumumu"}
            };
        }

        #region IPlantService Interface
        public async Task<List<PlantModel>> GetPlantsAsync() {
            Task<List<PlantModel>> task = new Task<List<PlantModel>>( () => _plants);
            return await task;
        }

        public IEnumerable<PlantModel> GetPlants() {
            return _plants;
        }

        public async Task<PlantModel> GetPlantAsync(long plantId) {
            return GetPlant(plantId);
        }

        public PlantModel GetPlant(long plantId) {
            return _plants.FirstOrDefault(p => p.Id == plantId);
        }

        public async Task<bool> EditPlantAsync(PlantModel plantModel) {
            return true;
        }

        public async Task<PlantModel> AddPlantAsync(PlantModel plantModel) {
            PlantModel existingPlant = _plants.FirstOrDefault(p => p.Id == plantModel.Id);
            if (existingPlant == null){
                _plants.Add(plantModel);
                existingPlant = plantModel;
            }
            return existingPlant;
        }

        public async Task<PlantModel> DeletePlantAsync(long id) {
            PlantModel existingPlant = _plants.FirstOrDefault(p => p.Id == id);
            if (existingPlant != null){
                _plants.Remove(existingPlant);
            }
            return existingPlant;
        }

        public bool PlantExists(long id) {
            return _plants.Any(p => p.Id == id);
        }
        #endregion
    }
}