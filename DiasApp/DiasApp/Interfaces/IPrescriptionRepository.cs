using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IPrescriptionRepository : IDisposable
    {
        Task<List<Prescription>> GetPrescriptions();
        Prescription GetPrescriptionByID(int PrescriptionId);
        void InsertPrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
        void UpdatePrescription(Prescription prescription);
        bool PrescriptionExists(int id);
        Task Save();
        Task<List<Prescription>> GetPrescriptionWithPredicate(Expression<Func<Prescription, bool>> predicate);
    }
}
