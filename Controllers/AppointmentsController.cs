using AdvisoryApp.Models;
using AdvisoryApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdvisoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentServices appointmentService;

        public AppointmentsController(IAppointmentServices appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public ActionResult<List<Appointment>> Get()
        {
            var appointments = appointmentService.Get();
            return appointments;
        }

        // GET: api/Appointments/{id}
        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }

            return appointment;
        }

        // POST: api/Appointments
        [HttpPost]
        public ActionResult<Appointment> Post([FromBody] Appointment appointment)
        {
            appointmentService.Create(appointment);

            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        // PUT: api/Appointments/{id}
        [HttpPut("{id}")]
        public ActionResult<Appointment> Put(string id, [FromBody] Appointment updatedAppointment)
        {
            var existingAppointment = appointmentService.Get(id);

            if (existingAppointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }

            updatedAppointment.Id = id;
            try
            {
               // appointmentService.Update(updatedAppointment);
            }
            catch (Exception ex)
            {
                // Handle the exception accordingly
                return StatusCode(500, $"An error occurred while updating the appointment: {ex.Message}");
            }

            return Ok(updatedAppointment);
        }

        // DELETE: api/Appointments/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }

            appointmentService.Remove(id);

            return Ok($"Appointment with Id = {id} deleted");
        }
    }
}