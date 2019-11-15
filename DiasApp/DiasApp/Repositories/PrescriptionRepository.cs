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
    public class PrescriptionRepository : IPrescriptionRepository, IDisposable
    {
        private PharmacyContext context;

        public PrescriptionRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Prescription>> GetPrescriptions()
        {
            return context.Prescription.ToListAsync();
        }

        public Prescription GetPrescriptionByID(int id)
        {
            return context.Prescription.Find(id);
        }

        public void InsertPrescription(Prescription prescription)
        {
            context.Prescription.Add(prescription);
        }

        public void DeletePrescription(Prescription prescription)
        {
            //Prescription prescription = context.Prescription.Find(prescriptionID);
            context.Prescription.Remove(prescription);
        }

        public void UpdatePrescription(Prescription prescription)
        {
            context.Entry(prescription).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool PrescriptionExists(int id)
        {
            return context.Prescription.Any(e => e.Id == id);
        }

        public Task<List<Prescription>> GetPrescriptionWithPredicate(Expression<Func<Prescription, bool>> predicate)
        {
            return context.Prescription.Where(predicate).ToListAsync();
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
