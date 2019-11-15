using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Interfaces;

namespace DiasApp.Services
{
    public class OrganizationService
    {
        private readonly IOrganizationRepository _organizationRepo;

        public OrganizationService(IOrganizationRepository organizationRepo)
        {
            _organizationRepo = organizationRepo;
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            return await _organizationRepo.GetOrganizations();
        }

        public async Task Save(Organization organization)
        {
            await _organizationRepo.Save();
        }

        public async Task Insert(Organization organization)
        {
            _organizationRepo.InsertOrganization(organization);
            await _organizationRepo.Save();
        }

        public async Task Update(Organization organization)
        {
            _organizationRepo.UpdateOrganization(organization);
            await _organizationRepo.Save();
        }

        public Organization GetOrganizationByID(int id)
        {
            return _organizationRepo.GetOrganizationByID(id);
        }

        public async Task Delete(Organization organization)
        {
            _organizationRepo.DeleteOrganization(organization);
            await _organizationRepo.Save();
        }

        public bool OrganizationExists(int id)
        {
            return _organizationRepo.OrganizationExists(id);
        }

        public async Task<List<Organization>> Search(string text)
        {
            text = text.ToLower();
            var searchedOrganizations = await _organizationRepo.GetOrganizationWithPredicate(organization => organization.Name.ToLower().Contains(text)
                                            || organization.Address.ToLower().Contains(text));

            return searchedOrganizations;
        }
    }
}
