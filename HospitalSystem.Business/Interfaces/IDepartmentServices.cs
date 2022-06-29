using HospitalSystem.Repository.Entities;
using System.Collections.Generic;

namespace HospitalSystem.Business.Services
{
    public interface IDepartmentServices
    {
        void CreatDepartment(string name, string address);
        void CreatDepartment(string depName, string depAddress, int docNumber, int patNumber);
        void DeleteDepartament(int depId);
        List<DepartmentModel> GetDepartment();
    }
}