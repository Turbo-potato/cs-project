using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IPatientRepository : IDisposable
    {
        Task<List<Patient>> GetPatients();
        Patient GetPatientByID(int PatientId);
        void InsertPatient(Patient patient);
        void DeletePatient(Patient patient);
        void UpdatePatient(Patient patient);
        bool PatientExists(int id);
        Task Save();
        Task<List<Patient>> GetPatientWithPredicate(Expression<Func<Patient, bool>> predicate);
    }
}
