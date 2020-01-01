using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WP.WebAPI.Models;
using WP.WebAPI.Services;

namespace WP.WebAPI.Services {
    public class PlantService : IPlantsService {
        private readonly WPContext _context;

        public PlantService(WPContext context) {
            _context = context;
        }
        
        public async Task<IEnumerable<PlantModel>>PlantModel(long id) {
            return await _context.PlantModels.ToListAsync();
        }


        # region IPlantService Interface
        public async Task<List<PlantModel>> GetPlantsAsync() {
            return await _context.PlantModels.ToListAsync();
        }

        public IEnumerable<PlantModel> GetPlants() {
            return _context.PlantModels.ToList();
        }

        public Task<PlantModel> GetPlantAsync(long plantId) {
            return _context.PlantModels.FindAsync(plantId).AsTask();
        }

        public PlantModel GetPlant(long plantId) {
            return _context.PlantModels.Find(plantId);
        }

        public async Task<bool> EditPlantAsync(PlantModel plantModel) {
            _context.Entry(plantModel).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                return false;
            }
            
            return true;
        }
        public async Task<PlantModel> AddPlantAsync(PlantModel plantModel) {
            _context.PlantModels.Add(plantModel);
            await _context.SaveChangesAsync();
            return await GetPlantAsync(plantModel.Id);
        }

        public async Task<PlantModel> DeletePlantAsync(long plantModelId) {
            PlantModel deletingPlant = await GetPlantAsync(plantModelId);
            if (deletingPlant == null) {
                return deletingPlant;
            }

            _context.PlantModels.Remove(deletingPlant);
            await _context.SaveChangesAsync();
            return deletingPlant;
        }

        public bool PlantExists(long id) {
            return _context.PlantModels.Any(e => e.Id == id);
        }
        #endregion
    }
}