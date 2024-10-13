using HospitalAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentSystem.Repositories.Abstracts;
public interface IAppointmentRepository : IEntityRepository<Appointment, Guid>
{
    public List<Appointment> GetAppointmentsByDoctorId(int doctorId);

}