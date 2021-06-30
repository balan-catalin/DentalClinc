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
    public class ServicesController : ControllerBase
    {
        private readonly IRepository _repository;

        public ServicesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<IActionResult> GetService()
        {
            return Ok(await _repository.Service.GetAllAsync());
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _repository.Service.FindByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.Id)
            {
                return BadRequest();
            }

            var dbService = await _repository.Service.FindByIdAsync(id);

            if (dbService != null)
            {
                dbService.MapDbServiceService(service);
                _repository.Service.Update(dbService);
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

        // POST: api/Services
        [HttpPost]
        public async Task<IActionResult> PostService([FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Service.Add(service);
            await _repository.SaveAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _repository.Service.FindByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            _repository.Service.Remove(service);

            await _repository.SaveAsync();

            return Ok(service);
        }
    }
}