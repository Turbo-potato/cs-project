using DiasApp.Data;
using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiasApp.Services
{
    public class DoctorRepository : IDoctorRepository, IDisposable
    {
        private PharmacyContext context;

        public DoctorRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Doctor>> GetDoctors()
        {
            return context.Doctor.ToListAsync();
        }

        public Doctor GetDoctorByID(int id)
        {
            return context.Doctor.Find(id);
        }

        public void InsertDoctor(Doctor doctor)
        {
            context.Doctor.Add(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            //Doctor doctor = context.Doctor.Find(doctorID);
            context.Doctor.Remove(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            context.Entry(doctor).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool DoctorExists(int id)
        {
            return context.Doctor.Any(e => e.Id == id);
        }

        public Task<List<Doctor>> GetDoctorWithPredicate(Expression<Func<Doctor, bool>> predicate)
        {
            return context.Doctor.Where(predicate).ToListAsync();
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
