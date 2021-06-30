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
    public class PatientAllergiesController : ControllerBase
    {
        private readonly IRepository _repository;

        public PatientAllergiesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PatientAllergies
        [HttpGet]
        public async Task<IActionResult> GetPatientAllergy()
        {
            return Ok(await _repository.PatientAllergy.GetAllAsync(new PatientAllergyWithPatientAndAllergySpecification()));
        }

        // GET: api/PatientAllergies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAllergy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientAllergy = await _repository.PatientAllergy.GetFirstOrDefaultAsync(
                new PatientAllergyWithPatientAndAllergySpecification(id));

            if (patientAllergy == null)
            {
                return NotFound();
            }

            return Ok(patientAllergy);
        }

        // PUT: api/PatientAllergies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientAllergy([FromRoute] int id, [FromBody] PatientAllergy patientAllergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientAllergy.Id)
            {
                return BadRequest();
            }

            var dbPatientAllergy =
                await _repository.PatientAllergy.GetFirstOrDefaultAsync(
                    new PatientAllergyWithPatientAndAllergySpecification(id));

            if (dbPatientAllergy != null)
            {
                dbPatientAllergy.MapDbPatientAllergyPatientAllergy(patientAllergy);
                _repository.PatientAllergy.Update(dbPatientAllergy);
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

        // POST: api/PatientAllergies
        [HttpPost]
        public async Task<IActionResult> PostPatientAllergy([FromBody] PatientAllergy patientAllergy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.PatientAllergy.Add(patientAllergy);
            await _repository.SaveAsync();

            return CreatedAtAction("GetPatientAllergy", new {id = patientAllergy.Id}, patientAllergy);
        }

        // DELETE: api/PatientAllergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAllergy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientAllergy = await _repository.PatientAllergy.FindByIdAsync(id);

            if (patientAllergy == null)
            {
                return NotFound();
            }

            _repository.PatientAllergy.Remove(patientAllergy);
            await _repository.SaveAsync();

            return Ok(patientAllergy);
        }
    }
}