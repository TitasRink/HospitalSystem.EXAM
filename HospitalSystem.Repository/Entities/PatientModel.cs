using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Repository.Entities
{
    public class PatientModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public int? DepartmentModelId { get; set; }
        public List<DoctorModel> doctors { get; set; }

        public PatientModel(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
            doctors = new List<DoctorModel>();
        }
    }
}
