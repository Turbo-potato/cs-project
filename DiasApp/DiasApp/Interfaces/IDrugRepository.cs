using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IDrugRepository : IDisposable
    {
        Task<List<Drug>> GetDrugs();
        Drug GetDrugByID(int DrugId);
        void InsertDrug(Drug drug);
        void DeleteDrug(Drug drug);
        void UpdateDrug(Drug drug);
        bool DrugExists(int id);
        Task Save();
        Task<List<Drug>> GetDrugWithPredicate(Expression<Func<Drug, bool>> predicate);
    }
}
