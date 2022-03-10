namespace Patient.Web.Controllers
{
    using Patient.Web.Application.Dtos;
    using Patient.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    [ApiController]
    public class PatientController
    {
        private readonly ILogger<PatientController> logger;
        private readonly IPatientsHandler patientsHandler;

        public PatientController(ILogger<PatientController> logger, IPatientsHandler patientsHandler)
        {
            this.logger = logger;
            this.patientsHandler = patientsHandler;
        }

        [HttpGet("GetAllPatientPrescriptions")]
        public async Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionsAsync([FromQuery] int idPatient)
        {
            return await patientsHandler.GetAllPatientPrescriptionAsync(idPatient);
        }

        [HttpGet("GetAllPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAlltPatientAppointmentsAsync(int idPatient)
        {
            return await patientsHandler.GetAllPatientAppointmentsAsync(idPatient);
        }

        [HttpGet("GetClosestPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointmentsAsync(int idPatient)
        {
            return await patientsHandler.GetClosestPatientAppointmentsAsync(idPatient);
        }

        [HttpPost("AddAppointment")]
        public async Task AddAppointmentAsync([FromBody] AppointmentDto appointmentDto)
        {

            await patientsHandler.AddAppointmentAsync(appointmentDto);
        }


        [HttpDelete("DeleteAppointment")]
        public async Task DeleteAppointmentAsync([FromQuery] int idAppointment)
        {
            await patientsHandler.DeleteAppointmentAsync(idAppointment);
        }

    }

}
