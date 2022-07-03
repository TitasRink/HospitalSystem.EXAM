using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.Business.Services
{
    public class PatientServices : IPatientServices
    {
        private DataDB Con { get; }

        public PatientServices(DataDB con)
        {
            Con = con;
        }

        public void CreatPatient(string name, string address, int docId)
        {
            PatientModel pat = new (name, address);
            var deptId = Con.Doctors.Where(x => x.Id == docId).FirstOrDefault().DepartmentModelId;
            pat.DepartmentModelId = deptId;
            var dep = Con.Departments
                .Include(x => x.doctors.Where(x => x.Id == docId))
                .Include(x => x.patients)
                .Where(x => x.doctors.Any(x => x.Id == docId))
                .FirstOrDefault();
            foreach (var doctor in dep.doctors)
            {
                doctor.patients.Add(pat);
            }
            Con.SaveChanges();
        }

        public List<PatientModel> ShowDepPatients(int depId)
        {
            var result = Con.Departments.Include(d => d.patients).FirstOrDefault(d => d.Id == depId).patients.ToList();
            return result;
        }

        public List<PatientModel> ShowDocPatients(int docId)
        {
            return Con.Patients.Where(x=>x.doctors.Any(x=>x.Id==docId)).ToList();
        }
    }
}
