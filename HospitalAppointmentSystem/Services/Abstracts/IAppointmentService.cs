using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Response;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.ReturnModels;

namespace HospitalAppointmentSystem.Services.Abstracts;
public interface IAppointmentService
{
    ReturnModel<Appointment> Add(Appointment appointment);
    Appointment Update(Appointment appointment);
    Appointment Delete(Guid id);
    List<Appointment> GetAll();
    Appointment GetById(Guid id);
}