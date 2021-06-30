using System.Linq;
using System.Threading.Tasks;
using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Extensions;
using Entities.Specification;

namespace APIsDentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalitiesController : ControllerBase
    {
        private readonly IRepository _repository;

        public LocalitiesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Localities
        [HttpGet]
        public async Task<IActionResult> GetLocality()
        {
            return Ok(await _repository.Locality.GetAllAsync());
        }

        // GET: api/Localities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocality([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locality = await _repository.Locality.GetFirstOrDefaultAsync(
                new LocalityWithCountySpecification(id));

            if (locality == null)
            {
                return NotFound();
            }

            return Ok(locality);
        }

        // PUT: api/Localities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocality(
            [FromRoute] int id, 
            [FromBody] Locality locality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locality.Id)
            {
                return BadRequest();
            }

            var dbLocality = await _repository.Locality.GetFirstOrDefaultAsync(
                new LocalityWithCountySpecification(id));

            if (dbLocality != null)
            {
                dbLocality.MapDbLocalityLocality(locality);
                _repository.Locality.Update(dbLocality);
            }
            else
            {
                return NotFound("The element to update was not found.");
            }

            try
            {
                var result = await _repository.SaveAsync();
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/Localities
        [HttpPost]
        public async Task<IActionResult> PostLocality([FromBody] Locality locality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Locality.Add(locality);
            await _repository.SaveAsync();

            return CreatedAtAction("GetLocality", new { id = locality.Id }, locality);
        }

        // DELETE: api/Localities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocality([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locality = await _repository.Locality.FindByIdAsync(id);

            if (locality == null)
            {
                return NotFound();
            }

            _repository.Locality.Remove(locality);
            await _repository.SaveAsync();

            return Ok(locality);
        }

        [HttpGet("GetByCountyId/{id}")]
        public async Task<IActionResult> GetLocalitiesByCouty(int id)
        {
            return Ok(await _repository.Locality.GetAllAsync(new LocalityWithCountySpecification(x => x.CountyId == id)));
        }
    }
}