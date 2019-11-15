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
    public class ManufacturerRepository : IManufacturerRepository, IDisposable
    {
        private PharmacyContext context;

        public ManufacturerRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Manufacturer>> GetManufacturers()
        {
            return context.Manufacturer.ToListAsync();
        }

        public Manufacturer GetManufacturerByID(int id)
        {
            return context.Manufacturer.Find(id);
        }

        public void InsertManufacturer(Manufacturer manufacturer)
        {
            context.Manufacturer.Add(manufacturer);
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            //Manufacturer manufacturer = context.Manufacturer.Find(manufacturerID);
            context.Manufacturer.Remove(manufacturer);
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            context.Entry(manufacturer).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool ManufacturerExists(int id)
        {
            return context.Manufacturer.Any(e => e.Id == id);
        }

        public Task<List<Manufacturer>> GetManufacturerWithPredicate(Expression<Func<Manufacturer, bool>> predicate)
        {
            return context.Manufacturer.Where(predicate).ToListAsync();
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
