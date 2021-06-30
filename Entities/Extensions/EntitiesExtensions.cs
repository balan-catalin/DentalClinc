namespace Entities.Extensions
{
    public static class EntitiesExtensions
    {
        public static Allergy MapDbAllergyAllergy(this Allergy dbAllergy, Allergy allergy)
        {
            dbAllergy.Id = allergy.Id;
            dbAllergy.AllergyName = allergy.AllergyName;

            return dbAllergy;
        }

        public static Locality MapDbLocalityLocality(this Locality dbLocality, Locality locality)
        {
            dbLocality.Id = locality.Id;
            dbLocality.Name = locality.Name;

            return dbLocality;
        }

        public static County MapDbCountyCounty(this County dbCounty, County county)
        {
            dbCounty.Id = county.Id;
            dbCounty.Name = county.Name;

            return dbCounty;
        }

        public static Service MapDbServiceService(this Service dbService, Service service)
        {
            dbService.Id = service.Id;
            dbService.ServiceName = service.ServiceName;
            dbService.Price = service.Price;

            return dbService;
        }

        public static Patient MapDbPatientPatient(this Patient dbPatient, Patient patient)
        {
            dbPatient.Id = patient.Id;
            dbPatient.Name = patient.Name;
            dbPatient.Adress = patient.Adress;
            dbPatient.EmailAdress = patient.EmailAdress;
            dbPatient.LocalityId = patient.LocalityId;
            dbPatient.Pin = patient.Pin;
            dbPatient.ReprezentativeName = patient.ReprezentativeName;
            dbPatient.ReprezentativePin = patient.ReprezentativePin;
            dbPatient.PhoneNumber = patient.PhoneNumber;

            return dbPatient;
        }

        public static PatientAllergy MapDbPatientAllergyPatientAllergy(this PatientAllergy dbPatientAllergy, PatientAllergy patientAllergy)
        {
            dbPatientAllergy.Id = patientAllergy.Id;
            dbPatientAllergy.PatientId = patientAllergy.PatientId;
            dbPatientAllergy.AllergyId = patientAllergy.AllergyId;

            return dbPatientAllergy;
        }

        public static PatientService MapDbPatientServicePatientService(this PatientService dbPatientService,
            PatientService patientService)
        {
            dbPatientService.Id = patientService.Id;
            dbPatientService.PatientId = patientService.PatientId;
            dbPatientService.ServiceId = patientService.ServiceId;
            dbPatientService.PriceAtSelection = patientService.PriceAtSelection;

            return dbPatientService;
        }
    }
}
