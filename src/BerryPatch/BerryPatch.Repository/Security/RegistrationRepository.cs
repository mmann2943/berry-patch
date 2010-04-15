using System;
namespace BerryPatch.Repository.Security
{
    public interface RegistrationRepository
    {
        void Register(string registrationCode);      
        bool IsValidRegCode(string registrationCode);
        void DeactivateRegCode(string RegistrationCode);
        int NumberOfTimesRegCodeEnteredToday(string registrationCode);

        bool PersonalInformationIsValid(string registrationCode, DateTime dateOfBirth, string zipCode);
    }
}