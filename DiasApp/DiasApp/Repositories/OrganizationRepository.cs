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
    public class OrganizationRepository : IOrganizationRepository, IDisposable
    {
        private PharmacyContext context;

        public OrganizationRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<Organization>> GetOrganizations()
        {
            return context.Organization.ToListAsync();
        }

        public Organization GetOrganizationByID(int id)
        {
            return context.Organization.Find(id);
        }

        public void InsertOrganization(Organization organization)
        {
            context.Organization.Add(organization);
        }

        public void DeleteOrganization(Organization organization)
        {
            //Organization organization = context.Organization.Find(organizationID);
            context.Organization.Remove(organization);
        }

        public void UpdateOrganization(Organization organization)
        {
            context.Entry(organization).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public bool OrganizationExists(int id)
        {
            return context.Organization.Any(e => e.Id == id);
        }

        public Task<List<Organization>> GetOrganizationWithPredicate(Expression<Func<Organization, bool>> predicate)
        {
            return context.Organization.Where(predicate).ToListAsync();
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
