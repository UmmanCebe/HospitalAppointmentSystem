using HospitalAppointmentSystem.Contexts;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repositories.Abstracts;
using System.Numerics;

namespace HospitalAppointmentSystem.Repositories.Concretes
{
    public class EfAppointmentRepository : IAppointmentRepository
    {
        private readonly MsSqlContext _msSqlContext;

        public EfAppointmentRepository(MsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public Appointment Add(Appointment entity)
        {
            _msSqlContext.Add(entity);
            _msSqlContext.SaveChanges();
            return entity;
        }

        public Appointment Delete(Guid id)
        {
            Appointment? entity = _msSqlContext.Appointments.Find(id);
            _msSqlContext.Remove(entity);
            _msSqlContext.SaveChanges();
            return entity;
        }

        public List<Appointment> GetAll()
        {
            _msSqlContext.SaveChanges();
            return _msSqlContext.Appointments.ToList();

        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _msSqlContext.Appointments.Where(x => x.DoctorId == doctorId).ToList();
        }

        public Appointment GetById(Guid id)
        {
            Appointment entity = _msSqlContext.Appointments.Find(id);
            return entity;
        }

        public Appointment Update(Appointment entity)
        {
            _msSqlContext.Update(entity);
            _msSqlContext.SaveChanges();
            return entity;
        }
    }
}