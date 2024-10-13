using HospitalAppointmentSystem.Contexts;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repositories.Abstracts;

namespace HospitalAppointmentSystem.Repositories.Concretes;
public class EfDoctorRepository : IDoctorRepository
{
    private readonly MsSqlContext _msSqlContext;

    public EfDoctorRepository(MsSqlContext msSqlContext)
    {
        _msSqlContext = msSqlContext;
    }

    public Doctor Add(Doctor doctor)
    {
        _msSqlContext.Add(doctor);
        _msSqlContext.SaveChanges();
        return doctor;
    }

    public Doctor Delete(int id)
    {
        Doctor? doctor = _msSqlContext.Doctors.Find(id);
        _msSqlContext.Remove(doctor);
        _msSqlContext.SaveChanges();
        return doctor;
    }

    public List<Doctor> GetAll()
    {
        return _msSqlContext.Doctors.ToList();
    }

    public Doctor GetById(int id)
    {
        Doctor doctor =_msSqlContext.Doctors.Find(id);
        return doctor;
    }

    public Doctor Update(Doctor doctor)
    {
        _msSqlContext.Update(doctor);
        _msSqlContext.SaveChanges();
        return doctor;
    }
}