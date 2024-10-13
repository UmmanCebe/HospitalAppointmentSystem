using HospitalAppointmentSystem.Enums;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;

namespace HospitalAppointmentSystem.Models;
public class Doctor : Entity<int>
{
    public string Name { get; set; }
    public BranchType Branch { get; set; }
    public List<Appointment> Patients { get; set; }
    public Doctor()
    {
        Patients = new List<Appointment>();
    }

    public static explicit operator Doctor(AddDoctorRequestDto dto)
    {
        return new Doctor
        {
            Name = dto.Name,
            Branch = dto.Branch,
        };
    }
}