using DiasApp.Data;
using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DiasApp.Interfaces;

namespace DiasApp.Repositories
{
    public class PatientRepository : IPatientRepository, IDisposable
    {
        private PharmacyContext context;

        public PatientRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Patient>> GetPatients()
        {
            return context.Patient.ToListAsync();
        }

        public Patient GetPatientByID(int id)
        {
            return context.Patient.Find(id);
        }

        public void InsertPatient(Patient patient)
        {
            context.Patient.Add(patient);
        }

        public void DeletePatient(Patient patient)
        {
            //Patient patient = context.Patient.Find(patientID);
            context.Patient.Remove(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool PatientExists(int id)
        {
            return context.Patient.Any(e => e.Id == id);
        }

        public Task<List<Patient>> GetPatientWithPredicate(Expression<Func<Patient, bool>> predicate)
        {
            return context.Patient.Where(predicate).ToListAsync();
        }

        //DISPOSING

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
