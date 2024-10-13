using HospitalAppointmentSystem.Enums;

namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
public class AddDoctorRequestDto
{
    public string Name { get; set; }
    public BranchType Branch { get; set; }
}