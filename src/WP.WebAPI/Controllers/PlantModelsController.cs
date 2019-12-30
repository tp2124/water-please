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
        // Issue #10 Remove this context once functionality is 100% abstracted into the plants service.
        private readonly WPContext _context;

        public PlantModelsController(WPContext context, IPlantsService plantService)
        {
            _plantService = plantService;
            _context = context;
        }
        #endregion

        // GET: api/PlantModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantModel>>> GetPlantModels()
        {
            return await _context.PlantModels.ToListAsync();
            // return await new Task<ActionResult<IEnumerable<PlantModel>>>(() => new ActionResult<IEnumerable<PlantModel>>(_plantService.GetPlants()));
        }

        #region snippet_GetByID
        // GET: api/PlantModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantModel>> GetPlantModel(long id)
        {
            PlantModel PlantModel = await _context.PlantModels.FindAsync(id);

            if (PlantModel == null)
            {
                return NotFound();
            }

            return PlantModel;
        }
        #endregion

        #region snippet_Update
        // PUT: api/PlantModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantModel(long id, PlantModel plantModel)
        {
            if (id != plantModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region snippet_Create
        // POST: api/PlantModels
        [HttpPost]
        public async Task<ActionResult<PlantModel>> PostPlantModel(PlantModel plantModel)
        {
            _context.PlantModels.Add(plantModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPlantModel", new { id = plantModel.Id }, plantModel);
            return CreatedAtAction(nameof(GetPlantModel), new { id = plantModel.Id }, plantModel);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PlantModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantModel>> DeletePlantModel(long id)
        {
            PlantModel plantModel = await _context.PlantModels.FindAsync(id);
            if (plantModel == null)
            {
                return NotFound();
            }

            _context.PlantModels.Remove(plantModel);
            await _context.SaveChangesAsync();

            return plantModel;
        }
        #endregion

        private bool PlantModelExists(long id)
        {
            return _context.PlantModels.Any(e => e.Id == id);
        }
    }
}