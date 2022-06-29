using HospitalSystem.Repository.Entities;
using System.Collections.Generic;

namespace HospitalSystem.Business.Services
{
    public interface IDoctorServices
    {
        void AddPatientToDoctor(int docNum, int patNum);
        void AddToDepartment(int depId, int doctorNum);
        void CreatDoctor(string name, string lastname, int age, int id);
        List<DoctorModel> Doctorinfo(int docId);
        List<DoctorModel> GetDepartmentDoctors(int depID);
    }
}