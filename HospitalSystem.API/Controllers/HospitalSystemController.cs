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
            var context = new dataDB();
            _departmentServices = new DepartmentServices(context);
            _doctorServices = new DoctorServices(context);
            _patientServices = new PatientServices(context);
        }

        [HttpPost]
        public void CreatDepartment(string name, string address)
        {
            _departmentServices.CreatDepartment(name, address);
        }
        [HttpPost("Create dep with doc and pat")]
        public void CreatDepartment(string depName, string depAddress, int docNumber, int patNumber)
        {
           _departmentServices.CreatDepartment(depName, depAddress, docNumber, patNumber);
        }

        [HttpPost("Change Doctors Departments ID")]
        public void AddDoctorToDepartment(int depId, int doctorId)
        {
            _doctorServices.AddToDepartment(depId, doctorId);
        }

        [HttpGet("List of Departments")]
        public List<DepartmentModel> GetDepartment()
        {
           return _departmentServices.GetDepartment();
        }

        [HttpPost("Create Doctor and add to dep")]
        public void CreatDoctor(string name, string address, int age, int depId)
        {
            _doctorServices.CreatDoctor(name, address, age, depId);
        }

        [HttpPost("Create Patient")]
        public void CreatPatient(string name, string address)
        {
            _patientServices.CreatPatient(name, address);
        }

        [HttpGet("List of Department-Doctors")]
        public List<DoctorModel> GetDoctors(int departmentID)
        {
            return _doctorServices.GetDepartmentDoctors(departmentID);
        }

        [HttpPost("Add Patient to Doctor")]
        public void AddPatient(int docNum, int patNum)
        {
            _doctorServices.AddPatientToDoctor(docNum, patNum);
        }

        [HttpGet("List Patient by Doctor ID")]
        public List<DoctorModel> GetPatientListFromDoctor(int departmentID)
        {
            return _doctorServices.Doctorinfo(departmentID);
        }
        [HttpDelete("Delete Department by ID")]
        public void RemoveDepartament(int depId)
        {
            _departmentServices.DeleteDepartament(depId);
        }
        [HttpGet("Show all department patients")]
        public List<PatientModel> ShowDepPatients(int departmentID)
        {
            return _patientServices.ShowDepPatients(departmentID);
        }
        //[HttpGet("Show all doctor patients")]
        //public List<PatientModel> ShowDocPatients(int docId)
        //{
        //    return _patientServices.ShowDocPatients(docId);
        //}
    }
}
