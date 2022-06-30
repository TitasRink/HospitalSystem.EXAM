using HospitalSystem.Repository.Entities;
using System.Collections.Generic;

namespace HospitalSystem.Business.Services
{
    public interface IPatientServices
    {
        void CreatPatient(string name, string address, int docId);
        List<PatientModel> ShowDepPatients(int depId);
        List<PatientModel> ShowDocPatients(int docId);
    }
}