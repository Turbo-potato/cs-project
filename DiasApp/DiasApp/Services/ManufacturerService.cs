using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Models;
using DiasApp.Interfaces;

namespace DiasApp.Services
{
    public class ManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepo;

        public ManufacturerService(IManufacturerRepository manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }

        public async Task<List<Manufacturer>> GetManufacturers()
        {
            return await _manufacturerRepo.GetManufacturers();
        }

        public async Task Save(Manufacturer manufacturer)
        {
            await _manufacturerRepo.Save();
        }

        public async Task Insert(Manufacturer manufacturer)
        {
            _manufacturerRepo.InsertManufacturer(manufacturer);
            await _manufacturerRepo.Save();
        }

        public async Task Update(Manufacturer manufacturer)
        {
            _manufacturerRepo.UpdateManufacturer(manufacturer);
            await _manufacturerRepo.Save();
        }

        public Manufacturer GetManufacturerByID(int id)
        {
            return _manufacturerRepo.GetManufacturerByID(id);
        }

        public async Task Delete(Manufacturer manufacturer)
        {
            _manufacturerRepo.DeleteManufacturer(manufacturer);
            await _manufacturerRepo.Save();
        }

        public bool ManufacturerExists(int id)
        {
            return _manufacturerRepo.ManufacturerExists(id);
        }

        public async Task<List<Manufacturer>> Search(string text)
        {
            text = text.ToLower();
            var searchedManufacturers = await _manufacturerRepo.GetManufacturerWithPredicate(manufacturer => manufacturer.Name.ToLower().Contains(text)
                                            || manufacturer.Address.ToLower().Contains(text));

            return searchedManufacturers;
        }
    }
}
