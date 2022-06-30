using HospitalSystem.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Repository.ContextDB
{
    public class DataDB : DbContext
    {
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=HospitalAPI;Trusted_Connection=True;");
        }
    }
}
// info i ateiti kaip galima padaryti destytojo kodas
//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Client>()
//        .HasOne(i => i.Restaurant)
//        .WithMany(i => i.Clients)
//        .IsRequired()
//        .OnDelete(DeleteBehavior.NoAction);
//}
