using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.Business.Services
{
    public class DoctorServices : IDoctorServices
    {
        private ContextDB Con { get; }

        public DoctorServices(ContextDB con)
        {
            Con = con;
        }

        public void CreatDoctor(string name, string lastname, int age, int id)
        {
            DoctorModel doc = new DoctorModel(name, lastname, age, id);
            Con.Add(doc);
            Con.SaveChanges();
        }

        public void AddToDepartment(int depId, int doctorNum)
        {
            var dep = Con.Departments.Where(x => x.Id == depId).SingleOrDefault();
            var doc = Con.Doctors.Where(x => x.Id == doctorNum).SingleOrDefault();
            dep.doctors.Add(doc);
            Con.SaveChanges();
        }

        public List<DoctorModel> GetDepartmentDoctors(int depID)
        {
            return Con.Doctors.Where(x => x.DepartmentModelId == depID).ToList();
        }

        public List<DoctorModel> Doctorinfo(int docId)
        {
            return Con.Doctors.Where(x => x.Id == docId).ToList();
        }

        public void AddPatientToDoctor(int docNum, int patNum)
        {
            var doc = Con.Doctors.Where(x => x.Id == docNum).FirstOrDefault();
            var pat = Con.Patients.Include(i => i.doctors).Where(x => x.Id == patNum).FirstOrDefault();
            doc.patients.Add(pat);
            pat.doctors.Clear();
            Con.SaveChanges();
        }
    }
}
