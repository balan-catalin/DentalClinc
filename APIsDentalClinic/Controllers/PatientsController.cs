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
    public class PatientsController : ControllerBase
    {
        private readonly IRepository _repository;

        public PatientsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<IActionResult> GetPatient()
        {
            return Ok(await _repository.Patient.GetAllAsync(new PatientWithLocalitySpecification()));
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await _repository.Patient.GetFirstOrDefaultAsync(new PatientWithLocalitySpecification(id));

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient([FromRoute] int id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            var dbPatient = await _repository.Patient.GetFirstOrDefaultAsync(new PatientWithLocalitySpecification(id));

            if (dbPatient != null)
            {
                dbPatient.MapDbPatientPatient(patient);
                _repository.Patient.Update(dbPatient);
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

        // POST: api/Patients
        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Patient.Add(patient);
            await _repository.SaveAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await _repository.Patient.FindByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _repository.Patient.Remove(patient);
            await _repository.SaveAsync();

            return Ok(patient);
        }
    }
}