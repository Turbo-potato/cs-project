using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Interfaces;

namespace DiasApp.Services
{
    public class DrugService
    {
        private readonly IDrugRepository _drugRepo;

        public DrugService(IDrugRepository drugRepo)
        {
            _drugRepo = drugRepo;
        }

        public async Task<List<Drug>> GetDrugs()
        {
            return await _drugRepo.GetDrugs();
        }

        public async Task Save(Drug drug)
        {
            await _drugRepo.Save();
        }

        public async Task Insert(Drug drug)
        {
            _drugRepo.InsertDrug(drug);
            await _drugRepo.Save();
        }

        public async Task Update(Drug drug)
        {
            _drugRepo.UpdateDrug(drug);
            await _drugRepo.Save();
        }

        public Drug GetDrugByID(int id)
        {
            return _drugRepo.GetDrugByID(id);
        }

        public async Task Delete(Drug drug)
        {
            _drugRepo.DeleteDrug(drug);
            await _drugRepo.Save();
        }

        public bool DrugExists(int id)
        {
            return _drugRepo.DrugExists(id);
        }

        public async Task<List<Drug>> Search(string text)
        {
            text = text.ToLower();
            var searchedDrugs = await _drugRepo.GetDrugWithPredicate(drug => drug.Name.ToLower().Contains(text)
                                            || drug.Type.ToLower().Contains(text)
                                            || drug.Description.ToLower().Contains(text));

            return searchedDrugs;
        }
    }
}
