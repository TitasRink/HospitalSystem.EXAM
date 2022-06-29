using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Repository.Entities
{
    public class DoctorModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Speciality { get; set; }
        [Required]
        public int Age { get; set; }
        public int DepartmentModelId { get; set; }
        public List<PatientModel> patients { get; set; }

        public DoctorModel(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            patients = new List<PatientModel>();
        }

        public DoctorModel(string name, string lastName, int age, int depId)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            DepartmentModelId = depId;
            patients = new List<PatientModel>();
        }
    }
}
