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
        public IEnumerable<PlantModel> GetPlants() {
            return _context.PlantModels.ToList();
        }

        public async Task<IEnumerable<PlantModel>>GetPlantsAsync() {
            return await _context.PlantModels.ToListAsync();
        }

        public PlantModel GetPlant(long plantId) {
            return _context.PlantModels.Find(plantId);
        }

        public bool EditPlant(long plantId, PlantModel plantModel) {
            // if (plantId != plantModel.Id)
            // {
            //     return false;
            // }

            // _context.Entry(plantModel).State = EntityState.Modified;

            // try
            // {
            //     _context.SaveChangesAsync().Result;
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!PlantModelExists(plantId))
            //     {
            //         return false;
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }
            return true;
        }
        public PlantModel AddPlant(PlantModel plantModel) {
            return null;
        }

        public PlantModel DeletePlant(PlantModel plantModel) {
            return null;
        }

        public bool PlantExists(long id) {
            return false;
        }
        #endregion
    }
}