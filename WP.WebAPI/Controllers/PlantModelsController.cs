using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WP.WebAPI.Models;

namespace WP.WebAPI.Controllers
{
    #region WP.WebAPI
    [Route("api/[controller]")]
    [ApiController]
    public class PlantModelsController : ControllerBase
    {
        private readonly WPContext _context;

        public PlantModelsController(WPContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/PlantModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantModel>>> GetPlantModels()
        {
            return await _context.PlantModels.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/PlantModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantModel>> GetPlantModel(long id)
        {
            var PlantModel = await _context.PlantModels.FindAsync(id);

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
        public async Task<IActionResult> PutPlantModel(long id, PlantModel PlantModel)
        {
            if (id != PlantModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(PlantModel).State = EntityState.Modified;

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
        public async Task<ActionResult<PlantModel>> PostPlantModel(PlantModel PlantModel)
        {
            _context.PlantModels.Add(PlantModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPlantModel", new { id = PlantModel.Id }, PlantModel);
            return CreatedAtAction(nameof(GetPlantModel), new { id = PlantModel.Id }, PlantModel);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PlantModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantModel>> DeletePlantModel(long id)
        {
            var PlantModel = await _context.PlantModels.FindAsync(id);
            if (PlantModel == null)
            {
                return NotFound();
            }

            _context.PlantModels.Remove(PlantModel);
            await _context.SaveChangesAsync();

            return PlantModel;
        }
        #endregion

        private bool PlantModelExists(long id)
        {
            return _context.PlantModels.Any(e => e.Id == id);
        }
    }
}