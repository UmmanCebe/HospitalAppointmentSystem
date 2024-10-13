using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Response;
using HospitalAppointmentSystem.Repositories.Abstracts;
using HospitalAppointmentSystem.Repositories.Concretes;
using HospitalAppointmentSystem.ReturnModels;
using HospitalAppointmentSystem.Services.Abstracts;

namespace HospitalAppointmentSystem.Services.Concretes;
public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public ReturnModel<Doctor> Add(AddDoctorRequestDto dto)
    {
        if (dto.Name == null || dto.Name == "")
        {
            return new ReturnModel<Doctor>
            {
                Data = null,
                Success = false,
                Message = "Doktor isim alanı boş bırakılamaz."
            };
        }

        Doctor doctor = (Doctor)dto;
        Doctor createdDoctor = _doctorRepository.Add(doctor);

        return new ReturnModel<Doctor>
        {
            Data = createdDoctor,
            Success = true,
            Message ="Doktor Başarı ile eklendi."
        };

    }

    public Doctor Delete(int id)
    {
        Doctor doctor = _doctorRepository.Delete(id);
        return doctor;
    }

    public List<DoctorResponseDto> GetAll()
    {
        return _doctorRepository.GetAll().Select(x => (DoctorResponseDto)x).ToList();
    }

    public Doctor GetById(int id)
    {
        Doctor doctor = _doctorRepository.GetById(id);
        return doctor;
    }

    public Doctor Update(Doctor doctor)
    {

        Doctor updateDoctor = _doctorRepository.Update(doctor);
        return updateDoctor;
    }
}