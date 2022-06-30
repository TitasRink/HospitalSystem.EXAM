using HospitalSystem.Business.Services;
using HospitalSystem.Repository.ContextDB;
using HospitalSystem.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalSystem.API.Controllers
{
    [Route("[Controller]")]
    public class HospitalSystemController : Controller
    {
        private IDepartmentServices _departmentServices { get; }
        private IDoctorServices _doctorServices { get; }
        private IPatientServices _patientServices { get; }
        public HospitalSystemController()
        {
            var context = new DataDB();
            _departmentServices = new DepartmentServices(context);
            _doctorServices = new DoctorServices(context);
            _patientServices = new PatientServices(context);
        }

        [HttpPost("Create department")]
        public void CreatDepartment(string name, string address)
        {
            _departmentServices.CreatDepartment(name, address);
        }

        [HttpPost("Create departament with doctors and patients")]
        public void CreatDepartment(string depName, string depAddress, int docNumber, int patNumber)
        {
           _departmentServices.CreatDepartment(depName, depAddress, docNumber, patNumber);
        }

        [HttpPost("Change Doctors Departments ID")]
        public void AddDoctorToDepartment(int depId, int doctorId)
        {
            _doctorServices.AddToDepartment(depId, doctorId);
        }

        [HttpPost("Create Doctor and add to department")]
        public void CreatDoctor(string name, string address, int age, int depId)
        {
            _doctorServices.CreatDoctor(name, address, age, depId);
        }

        [HttpPost("Create Patient")]
        public void CreatPatient(string name, string address, int docId)
        {
            _patientServices.CreatPatient(name, address, docId);
        }

        [HttpPost("Add Patient to Doctor")]
        public void AddPatient(int docNum, int patNum)
        {
            _doctorServices.AddPatientToDoctor(docNum, patNum);
        }

        [HttpGet("List of Departments")]
        public List<DepartmentModel> GetDepartment()
        {
            return _departmentServices.GetDepartment();
        }

        [HttpGet("List of Department-Doctors")]
        public List<DoctorModel> GetDoctors(int departmentID)
        {
            return _doctorServices.GetDepartmentDoctors(departmentID);
        }

        [HttpGet("List Patient by Doctor ID")]
        public List<DoctorModel> GetPatientListFromDoctor(int departmentID)
        {
            return _doctorServices.Doctorinfo(departmentID);
        }
       
        [HttpGet("Show all department patients")]
        public List<PatientModel> ShowDepPatients(int departmentID)
        {
            return _patientServices.ShowDepPatients(departmentID);
        }

        [HttpGet("Show all doctor patients")]
        public List<PatientModel> ShowDocPatients(int docId)
        {
            return _patientServices.ShowDocPatients(docId);
        }

        [HttpDelete("Delete Department by ID")]
        public void RemoveDepartament(int depId)
        {
            _departmentServices.DeleteDepartament(depId);
        }
    }
}
