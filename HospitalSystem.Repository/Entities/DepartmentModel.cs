using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Repository.Entities
{
    public class DepartmentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public List<DoctorModel> doctors { get; set; }
        public List<PatientModel> patients { get; set; }

        public DepartmentModel(string name, string address)
        {
            Name = name;
            Address = address;
            doctors = new List<DoctorModel>();
            patients = new List<PatientModel>();
        }
        public DepartmentModel(string name, string address, List<DoctorModel> doctors, List<PatientModel> patients)
        {
            Name = name;
            Address = address;
            this.doctors = doctors;
            this.patients = patients;
        }
    }
}
