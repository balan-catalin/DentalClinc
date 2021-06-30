using Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Utilities;

namespace Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        private IPatientRepository _patient;
        private ICountyRepository _county;
        private ILocalityRepository _locality;
        private IServiceRepository _service;
        private IAllergyRepository _allergy;
        private IPatientServiceRepository _patientService;
        private IPatientAllergyRepository _patientAllergy;


        public Repository(DbContext context)
        {
            _context = context;
        }

        public IPatientRepository Patient
        {
            get { return _patient ?? (_patient = new PatientRepository(_context)); }
        }

        public ICountyRepository County
        {
            get { return _county ?? (_county = new CountyRepository(_context)); }
        }

        public ILocalityRepository Locality
        {
            get { return _locality ?? (_locality = new LocalityRepository(_context)); }
        }

        public IServiceRepository Service
        {
            get { return _service ?? (_service = new ServiceRepository(_context)); }
        }

        public IAllergyRepository Allergy
        {
            get { return _allergy ?? (_allergy = new AllergyRepository(_context)); }
        }

        public IPatientServiceRepository PatientService
        {
            get { return _patientService ?? (_patientService = new PatientServiceRepository(_context)); }
        }

        public IPatientAllergyRepository PatientAllergy
        {
            get { return _patientAllergy ?? (_patientAllergy = new PatientAllergyRepository(_context)); }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


