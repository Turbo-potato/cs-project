using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepo;

        public DoctorService(IDoctorRepository doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _doctorRepo.GetDoctors();
        }

        public async Task Save(Doctor doctor)
        {
            await _doctorRepo.Save();
        }

        public async Task Insert(Doctor doctor)
        {
            _doctorRepo.InsertDoctor(doctor);
            await _doctorRepo.Save();
        }

        public async Task Update(Doctor doctor)
        {
            _doctorRepo.UpdateDoctor(doctor);
            await _doctorRepo.Save();
        }

        public Doctor GetDoctorByID(int id)
        {
           return _doctorRepo.GetDoctorByID(id);
        }

        public async Task Delete(Doctor doctor)
        {
            _doctorRepo.DeleteDoctor(doctor);
            await _doctorRepo.Save();
        }

        public bool DoctorExists(int id)
        {
            return _doctorRepo.DoctorExists(id);
        }

        public async Task<List<Doctor>> Search(string text)
        {
            text = text.ToLower();
            var searchedDoctors = await _doctorRepo.GetDoctorWithPredicate(doctor => doctor.Firstname.ToLower().Contains(text)
                                            || doctor.Lastname.ToLower().Contains(text)
                                            || doctor.Certificate.ToLower().Contains(text));

            return searchedDoctors;
        }

    }
}
