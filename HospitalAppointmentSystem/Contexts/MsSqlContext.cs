using HospitalAppointmentSystem.Enums;
using HospitalAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentSystem.Contexts;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .Property(a => a.Id)
            .HasDefaultValueSql("NEWID()");  // SQL Server için

        base.OnModelCreating(modelBuilder);
    }
}