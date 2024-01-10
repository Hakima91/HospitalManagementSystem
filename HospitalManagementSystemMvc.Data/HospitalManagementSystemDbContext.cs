using HospitalManagementSystemMvc.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemMvc.Data;

public class HospitalManagementSystemDbContext: IdentityDbContext<PatientEntity, IdentityRole<int>, int>

{
    public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options)
        : base(options) {}



    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<AppointmentEntity> Appointments{ get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    // public DbSet<BillingEntity> Billings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<PatientEntity>().ToTable("Patients");
        builder.Entity<DoctorEntity>().ToTable("Doctors");
        builder.Entity<AppointmentEntity>().ToTable("Appointments");
        builder.Entity<DepartmentEntity>().ToTable("Departments");
    
    }
}

  