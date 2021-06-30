using Entities;

namespace Contract
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        void Update(Patient patientDb, Patient patient);
    }
}

