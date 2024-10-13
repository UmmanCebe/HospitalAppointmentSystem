using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repositories.Abstracts;
using HospitalAppointmentSystem.Services.Abstracts;

namespace HospitalAppointmentSystem.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Appointment Add(Appointment appointment)
        {

           Appointment createdAppointment = _appointmentRepository.Add(appointment);
            return createdAppointment;
        }

        public Appointment Delete(Guid id)
        {
            var result = _appointmentRepository.Delete(id);
            return result;
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(Guid id)
        {
            var result = _appointmentRepository.GetById(id);
            return result;
        }

        public Appointment Update(Appointment appointment)
        {
            var result = _appointmentRepository.Update(appointment);
            return result;
        }
    }
}
