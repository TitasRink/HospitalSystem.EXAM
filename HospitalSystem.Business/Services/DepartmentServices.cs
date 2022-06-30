using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
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
            var departament = new DepartmentModel(name, address);
            Con.Departments.Add(departament);
            Con.SaveChanges();
        }

        public List<DepartmentModel> GetDepartment()
        {
            return Con.Departments.ToList();
        }

        public void CreatDepartment(string depName, string depAddress, int docNumber, int patNumber)
        {
            List<DoctorModel> doc = new List<DoctorModel>();
            for (int i = 0; i < docNumber; i++)
            {
                doc.Add(new DoctorModel($"Daktaras{i}", $"LastName{i}", 20 + i));
            }

            List<PatientModel> pat = new List<PatientModel>();
            for (int i = 0; i < patNumber; i++)
            {
                pat.Add(new PatientModel($"Pacientas{i}", $"LastName{i}"));
            }

            for (int i = 0; i < pat.Count; i++)
            {
                pat[i].doctors.AddRange(doc);
            }

            Con.Departments.Add(new DepartmentModel(depName, depAddress, doc, pat));
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
