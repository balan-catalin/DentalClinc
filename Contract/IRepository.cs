using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRepository : IDisposable
    {
        IPatientRepository Patient { get; }
        ICountyRepository County { get; }
        ILocalityRepository Locality { get; }
        IServiceRepository Service { get; }
        IAllergyRepository Allergy { get; }
        IPatientServiceRepository PatientService { get; }
        IPatientAllergyRepository PatientAllergy { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
