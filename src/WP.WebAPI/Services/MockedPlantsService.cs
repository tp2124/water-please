using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<PlantModel> GetPlants() {
            return _plants;
        }

        public PlantModel GetPlant(long plantId) {
            return _plants.FirstOrDefault(p => p.Id == plantId);
        }

        public bool EditPlant(long plantId, PlantModel plantModel) {
            return plantId == plantModel.Id;
        }

        public PlantModel AddPlant(PlantModel plantModel) {
            PlantModel existingPlant = _plants.FirstOrDefault(p => p.Id == plantModel.Id);
            if (existingPlant == null){
                _plants.Add(plantModel);
                existingPlant = plantModel;
            }
            return existingPlant;
        }

        public PlantModel DeletePlant(PlantModel plantModel) {
            PlantModel existingPlant = _plants.FirstOrDefault(p => p.Id == plantModel.Id);
            if (existingPlant != null){
                _plants.Remove(existingPlant);
            }
            return existingPlant;
        }

        public bool PlantExists(long id) {
            return _plants.Any(p => p.Id == id);
        }
    }
}