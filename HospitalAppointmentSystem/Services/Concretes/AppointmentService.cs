using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repositories.Abstracts;
using HospitalAppointmentSystem.ReturnModels;
using HospitalAppointmentSystem.Services.Abstracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalAppointmentSystem.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public ReturnModel<Appointment> Add(Appointment appointment)
        {
            DateTime today = DateTime.Now;

            if (appointment.AppointmentDate < today.AddDays(3))
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "En az 3 gün sonrasına randevu alabilirsiniz."
                };
            }

            if (appointment.DoctorId == 0)// buraya id kontrolü nasıl eklerim ilgili id yok ise mesela
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "Doktor id kısmı boş bırakılamaz."
                };
            }
            if (appointment.PatientName is null || appointment.PatientName == "")
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "Hasta isim alanı boş bırakılamaz."
                };
            }

                return new ReturnModel<Appointment>
                {

                    Data = _appointmentRepository.Add(appointment),
                    Success = true,
                    Message = "Randevu başarıyla oluşturuldu."
                };
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