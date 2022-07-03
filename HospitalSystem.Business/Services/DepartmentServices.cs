using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalSystem.Business.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private DataDB Con { get; }

        public DepartmentServices(DataDB con)
        {
            Con = con;
        }

        public void CreatDepartment(string name, string address)
        {
            Con.Departments.Add(new (name, address));
            Con.SaveChanges();
        }

        public List<DepartmentModel> GetDepartment()
        {
            return Con.Departments.Include(x=>x.doctors).Include(x=>x.patients).ToList();
        }

        public void CreatDepartment(string depName, string depAddress, int docNumber, int patNumber)
        {
            List<DoctorModel> doc = new List<DoctorModel>();
            for (int i = 0; i < docNumber; i++)
            {
                doc.Add(new ($"Daktaras{i}", $"LastName{i}", 20 + i));
            }

            List<PatientModel> pat = new List<PatientModel>();
            for (int i = 0; i < patNumber; i++)
            {
                pat.Add(new ($"Pacientas{i}", $"LastName{i}"));
            }

            for (int i = 0; i < pat.Count; i++)
            {
                pat[i].doctors.AddRange(doc);
            }

            Con.Departments.Add(new (depName, depAddress, doc, pat));
            Con.SaveChanges();
        }

        public void DeleteDepartament(int depId)
        {
            var getDepId = Con.Departments.Where(x => x.Id == depId).FirstOrDefault();
            Con.Departments.Remove(getDepId);
            Con.SaveChanges();
        }
    }
}
