using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiasApp.Interfaces;
using DiasApp.Models;

namespace DiasApp.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepo;

        public PrescriptionService(IPrescriptionRepository prescriptionRepo)
        {
            _prescriptionRepo = prescriptionRepo;
        }

        public async Task<List<Prescription>> GetPrescriptions()
        {
            return await _prescriptionRepo.GetPrescriptions();
        }

        public async Task Save(Prescription prescription)
        {
            await _prescriptionRepo.Save();
        }

        public async Task Insert(Prescription prescription)
        {
            _prescriptionRepo.InsertPrescription(prescription);
            await _prescriptionRepo.Save();
        }

        public async Task Update(Prescription prescription)
        {
            _prescriptionRepo.UpdatePrescription(prescription);
            await _prescriptionRepo.Save();
        }

        public Prescription GetPrescriptionByID(int id)
        {
            return _prescriptionRepo.GetPrescriptionByID(id);
        }

        public async Task Delete(Prescription prescription)
        {
            _prescriptionRepo.DeletePrescription(prescription);
            await _prescriptionRepo.Save();
        }

        public bool PrescriptionExists(int id)
        {
            return _prescriptionRepo.PrescriptionExists(id);
        }

        public async Task<List<Prescription>> Search(string text)
        {
            text = text.ToLower();
            var searchedPrescriptions = await _prescriptionRepo.GetPrescriptionWithPredicate(prescription => prescription.Instruction.ToLower().Contains(text)
                                            || prescription.PatientName.ToLower().Contains(text));

            return searchedPrescriptions;
        }
    }
}
