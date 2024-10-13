using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
using HospitalAppointmentSystem.Services.Abstracts;
using HospitalAppointmentSystem.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers;

[Route("api/appointments")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("getallappointments")]
    public IActionResult GetAll()
    {
        var result = _appointmentService.GetAll();
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var result = _appointmentService.GetById(id);
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Appointment appointment)
    {
        var result = _appointmentService.Add(appointment);
        if (!result.Success)
        {
            return BadRequest(new
            {
                StatusCode = 400,
                message = result.Message
            });
        }
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(Guid id, Appointment updatedAppointment)
    {
        var appointment = _appointmentService.GetById(id);
        appointment.PatientName = updatedAppointment.PatientName;
        appointment.AppointmentDate = updatedAppointment.AppointmentDate;
        appointment.DoctorId = updatedAppointment.DoctorId;
        appointment.Id = updatedAppointment.Id;

        var result = _appointmentService.Update(appointment);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(Guid id)
    {
        var result = _appointmentService.Delete(id);
        return Ok(result);
    }
}