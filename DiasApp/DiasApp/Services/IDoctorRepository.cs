using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Services
{
    public interface IDoctorRepository : IDisposable
    {
        Task<List<Doctor>> GetDoctors();
        Doctor GetDoctorByID(int doctorId);
        void InsertDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        bool DoctorExists(int id);
        Task Save();
        Task<List<Doctor>> GetDoctorWithPredicate(Expression<Func<Doctor, bool>> predicate);
    }
}
