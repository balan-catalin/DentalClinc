using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Extensions;
using Repositories;

namespace APIsDentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : ControllerBase
    {
        private readonly IRepository _repository;

        public CountiesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Counties
        [HttpGet]
        public async Task <IActionResult> GetCounty()
        {
            return Ok(await _repository.County.GetAllAsync());
        }

        // GET: api/Counties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCounty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var county = await _repository.County.FindByIdAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            return Ok(county);
        }

        // PUT: api/Counties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCounty([FromRoute] int id, [FromBody] County county)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != county.Id)
            {
                return BadRequest();
            }

            var dbCounty = await _repository.County.FindByIdAsync(id);

            if (dbCounty != null)
            {
                dbCounty.MapDbCountyCounty(county);
                _repository.County.Update(dbCounty);
            }
            else
            {
                return NotFound("The element to update was not found.");
            }

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

        // POST: api/Counties
        [HttpPost]
        public async Task<IActionResult> PostCounty([FromBody] County county)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.County.Add(county);
            await _repository.SaveAsync();

            return CreatedAtAction("GetCounty", new { id = county.Id }, county);
        }

        // DELETE: api/Counties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var county = await _repository.County.FindByIdAsync(id);

            if (county == null)
            {
                return NotFound();
            }

            _repository.County.Remove(county);
            await _repository.SaveAsync();

            return Ok(county);
        }

        [HttpGet("GetByLocalityId/{id}")]
        public async Task<IActionResult> GetByLocalityId(int id)
        {
            Locality loc = await _repository.Locality.FindByIdAsync(id);
            return Ok(await _repository.County.FindByIdAsync(loc.CountyId));
        }
    }
}