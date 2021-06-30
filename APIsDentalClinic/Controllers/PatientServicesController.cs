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
using Entities.Specification;
using Repositories;

namespace APIsDentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientServicesController : ControllerBase
    {
        private readonly IRepository _repository;

        public PatientServicesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PatientServices
        [HttpGet]
        public async Task<IActionResult> GetPatientService()
        {
            return Ok(await _repository.PatientService.GetAllAsync(
                new PatientServiceWithPatientAndServiceSpecification()));
        }

        // GET: api/PatientServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientService = await _repository.PatientService.GetFirstOrDefaultAsync(
                new PatientServiceWithPatientAndServiceSpecification(id));

            if (patientService == null)
            {
                return NotFound();
            }

            return Ok(patientService);
        }

        // PUT: api/PatientServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientService([FromRoute] int id, [FromBody] PatientService patientService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientService.Id)
            {
                return BadRequest();
            }

            var dbPatientService =
                await _repository.PatientService.GetFirstOrDefaultAsync(
                    new PatientServiceWithPatientAndServiceSpecification(id));

            if (dbPatientService != null)
            {
                dbPatientService.MapDbPatientServicePatientService(patientService);
                _repository.PatientService.Update(dbPatientService);
            }
            else
            {
                return NoContent();
            }

            try
            {
                var response = await _repository.SaveAsync();
                return Ok(response);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest();
            }
        }

        // POST: api/PatientServices
        [HttpPost]
        public async Task<IActionResult> PostPatientService([FromBody] PatientService patientService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.PatientService.Add(patientService);

            await _repository.SaveAsync();

            return CreatedAtAction("GetPatientService", new { id = patientService.Id }, patientService);
        }

        // DELETE: api/PatientServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientService = await _repository.PatientService.FindByIdAsync(id);
            if (patientService == null)
            {
                return NotFound();
            }

            _repository.PatientService.Remove(patientService);
            await _repository.SaveAsync();

            return Ok(patientService);
        }
    }
}