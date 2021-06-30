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
    public class AllergiesController : ControllerBase
    {
        private readonly IRepository _repository;

        public AllergiesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Allergies
        [HttpGet]
        public async Task<IActionResult> GetAllergy()
        {
            return Ok(await _repository.Allergy.GetAllAsync());
        }

        // GET: api/Allergies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            Allergy allergy = await _repository.Allergy.FindByIdAsync(id);

            if (allergy == null)
            {
                return NotFound("Item doesn't exist anymore!");
            }

            return Ok(allergy);
        }

        // PUT: api/Allergies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergy([FromRoute] int id, [FromBody] Allergy allergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allergy.Id)
            {
                return BadRequest();
            }

            var dbAlergy = await _repository.Allergy.FindByIdAsync(id);

            if (dbAlergy != null)
            {
                dbAlergy.MapDbAllergyAllergy(allergy);
                _repository.Allergy.Update(dbAlergy);
            }
            else
                return NotFound("The element to update was not found.");

            try
            {
                var response = await _repository.SaveAsync();
                return Ok(response);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/Allergies
        [HttpPost]
        public async Task<IActionResult> PostAllergy([FromBody] Allergy allergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Allergy.Add(allergy);
            await _repository.SaveAsync();

            return CreatedAtAction("GetAllergy", new { id = allergy.Id }, allergy);
        }

        // DELETE: api/Allergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Allergy allergy = await _repository.Allergy.FindByIdAsync(id);

            if (allergy == null)
            {
                return NotFound();
            }

            _repository.Allergy.Remove(allergy);
            await _repository.SaveAsync();

            return Ok(allergy);
        }
    }
}