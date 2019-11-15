using DiasApp.Data;
using DiasApp.Interfaces;
using DiasApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Repositories
{
    public class DrugRepository : IDrugRepository, IDisposable
    {
        private PharmacyContext context;

        public DrugRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Drug>> GetDrugs()
        {
            return context.Drug.ToListAsync();
        }

        public Drug GetDrugByID(int id)
        {
            return context.Drug.Find(id);
        }

        public void InsertDrug(Drug drug)
        {
            context.Drug.Add(drug);
        }

        public void DeleteDrug(Drug drug)
        {
            //Drug drug = context.Drug.Find(drugID);
            context.Drug.Remove(drug);
        }

        public void UpdateDrug(Drug drug)
        {
            context.Entry(drug).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool DrugExists(int id)
        {
            return context.Drug.Any(e => e.Id == id);
        }

        public Task<List<Drug>> GetDrugWithPredicate(Expression<Func<Drug, bool>> predicate)
        {
            return context.Drug.Where(predicate).ToListAsync();
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
