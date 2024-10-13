using HospitalAppointmentSystem.Enums;
using Microsoft.OpenApi.Extensions;

namespace HospitalAppointmentSystem.Models.Dtos.Doctors.Response;
public class DoctorResponseDto
{
    public string Name { get; set; }
    public string Branch { get; set; }
    public List<string> PatientsNames { get; set; }

    public static implicit operator DoctorResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto
        {
            Branch = doctor.Branch.ToString(),
            PatientsNames = doctor.Patients.Select(x => x.PatientName).ToList(),
            Name = doctor.Name
        };
    }
}