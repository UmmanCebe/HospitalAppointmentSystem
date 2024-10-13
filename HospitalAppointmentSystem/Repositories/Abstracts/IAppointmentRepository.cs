using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Repositories.Abstracts;
public interface IAppointmentRepository : IEntityRepository<Appointment, Guid>
{
}