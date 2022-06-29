using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.Business.Services
{
    public class PatientServices : IPatientServices
    {
        private ContextDB Con { get; }

        public PatientServices(ContextDB con)
        {
            Con = con;
        }

        public void CreatPatient(string name, string address)
        {
            PatientModel pat = new PatientModel(name, address);
            Con.Patients.Add(pat);
            Con.SaveChanges();
        }

        public List<PatientModel> ShowDepPatients(int depId)
        {
            var result = Con.Departments.Include(d => d.patients).FirstOrDefault(d => d.Id == depId).patients.ToList();
            return result;
        }
        //turi klaidu pataisyti
        public List<PatientModel> ShowDocPatients(int docId)
        {
            return Con.Doctors.Include(d => d.patients).FirstOrDefault(d => d.Id == docId).patients.ToList();
        }
    }
}
