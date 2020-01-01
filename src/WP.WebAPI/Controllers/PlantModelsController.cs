using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WP.WebAPI.Models;
using WP.WebAPI.Services;

namespace WP.WebAPI.Controllers
{
    #region WP.WebAPI
    [Route("api/[controller]")]
    [ApiController]
    public class PlantModelsController : ControllerBase
    {
        private readonly IPlantsService _plantService;

        public PlantModelsController(IPlantsService plantService)
        {
            _plantService = plantService;
        }
        #endregion

        // GET: api/PlantModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantModel>>> GetPlantModels()
        {
            return await _plantService.GetPlantsAsync();
        }

        #region GetByID
        // GET: api/PlantModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantModel>> GetPlantModel(long id)
        {
            PlantModel PlantModel = await _plantService.GetPlantAsync(id);

            if (PlantModel == null)
            {
                return NotFound();
            }

            return PlantModel;
        }
        #endregion

        #region Update
        // PUT: api/PlantModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantModel(long id, PlantModel plantModel)
        {
            if (id != plantModel.Id)
            {
                return BadRequest();
            }

            if (!await _plantService.EditPlantAsync(plantModel)) {
                if (!_plantService.PlantExists(id)) {
                    return NotFound();
                }
            }

            return NoContent();
        }
        #endregion

        #region Create
        // POST: api/PlantModels
        [HttpPost]
        public async Task<ActionResult<PlantModel>> PostPlantModel(PlantModel plantModel)
        {
            await _plantService.AddPlantAsync(plantModel);
            return CreatedAtAction(nameof(GetPlantModel), new { id = plantModel.Id }, plantModel);
        }
        #endregion

        #region Delete
        // DELETE: api/PlantModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantModel>> DeletePlantModel(long id)
        {
            PlantModel deletedPlant = await _plantService.DeletePlantAsync(id);
            if (deletedPlant == null) {
                return NotFound();
            }

            return deletedPlant;
        }
        #endregion
    }
}