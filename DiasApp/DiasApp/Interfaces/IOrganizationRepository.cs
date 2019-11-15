using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IOrganizationRepository : IDisposable
    {
        Task<List<Models.Organization>> GetOrganizations();
        Organization GetOrganizationByID(int OrganizationId);
        void InsertOrganization(Organization organization);
        void DeleteOrganization(Organization organization);
        void UpdateOrganization(Organization organization);
        bool OrganizationExists(int id);
        Task Save();
        Task<List<Organization>> GetOrganizationWithPredicate(Expression<Func<Organization, bool>> predicate);
    }
}
