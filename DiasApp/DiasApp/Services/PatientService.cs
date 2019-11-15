using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Interfaces;

namespace DiasApp.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _patientRepo;

        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _patientRepo.GetPatients();
        }

        public async Task Save(Patient patient)
        {
            await _patientRepo.Save();
        }

        public async Task Insert(Patient patient)
        {
            _patientRepo.InsertPatient(patient);
            await _patientRepo.Save();
        }

        public async Task Update(Patient patient)
        {
            _patientRepo.UpdatePatient(patient);
            await _patientRepo.Save();
        }

        public Patient GetPatientByID(int id)
        {
            return _patientRepo.GetPatientByID(id);
        }

        public async Task Delete(Patient patient)
        {
            _patientRepo.DeletePatient(patient);
            await _patientRepo.Save();
        }

        public bool PatientExists(int id)
        {
            return _patientRepo.PatientExists(id);
        }

        public async Task<List<Patient>> Search(string text)
        {
            text = text.ToLower();
            var searchedPatients = await _patientRepo.GetPatientWithPredicate(patient => patient.Firstname.ToLower().Contains(text)
                                            || patient.Lastname.ToLower().Contains(text));

            return searchedPatients;
        }
    }
}
