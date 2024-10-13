using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Response;
using System.Security.Cryptography;

namespace HospitalAppointmentSystem.Services.Abstracts;
public interface IDoctorService
{
    Doctor Add(AddDoctorRequestDto dto);
    Doctor Update(Doctor entity);
    Doctor Delete(int id);
    List<DoctorResponseDto> GetAll();
    Doctor GetById(int id);
}