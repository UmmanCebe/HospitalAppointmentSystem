using HospitalAppointmentSystem.Contexts;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Dtos.Doctors.Request;
using HospitalAppointmentSystem.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers;

[Route("api/doctors")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _doctorService.GetAll();
        return StatusCode(200, result); ;
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        var doctor = _doctorService.GetById(id);
        return StatusCode(200, doctor);
    }

    [HttpPost("add")]
    public IActionResult Add(AddDoctorRequestDto doctor)
    {
        var result = _doctorService.Add(doctor);
        return StatusCode(200, result);
    }

    //[HttpPut("update")]
    //public IActionResult Update(int id, Doctor updatedDoctor)
    //{
    //    var doctor = _doctorService.GetById(id);
    //    updatedDoctor = _doctorService.Update(doctor);
    //    return StatusCode(200, updatedDoctor);
    //}

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
       var result = _doctorService.Delete(id);
        return Ok(result);
    }
}