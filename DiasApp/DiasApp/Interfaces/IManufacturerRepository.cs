
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiasApp.Models;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IManufacturerRepository : IDisposable
    {
        Task<List<Manufacturer>> GetManufacturers();
        Manufacturer GetManufacturerByID(int ManufacturerId);
        void InsertManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        bool ManufacturerExists(int id);
        Task Save();
        Task<List<Manufacturer>> GetManufacturerWithPredicate(Expression<Func<Manufacturer, bool>> predicate);
    }
}
