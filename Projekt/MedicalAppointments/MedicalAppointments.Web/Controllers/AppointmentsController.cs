using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointments.Web.Controllers
{
    using MedicalAppointments.Domain;
    using MedicalAppointments.Web.Application;
    using MedicalAppointments.Web.Application.Dtos;
    using MedicalAppointments.Web.Application.Queries;
    using MedicalAppointments.Web.Application.Commands;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> logger;
        private readonly IAppointmentQueriesHandler appointmentQueriesHandler;
        private readonly ICommandHandler<AddAppointmentCommand> addAppointmentCommandHandler;
        private readonly ICommandHandler<DeleteAppointmentCommand> deleteAppointmentCommandHandler;

        public AppointmentsController(ILogger<AppointmentsController> logger, IAppointmentQueriesHandler appointmentQueriesHandler, ICommandHandler<AddAppointmentCommand> addAppointmentCommandHandler, ICommandHandler<DeleteAppointmentCommand> deleteAppointmentCommandHandler)
        {
            this.logger = logger;
            this.appointmentQueriesHandler = appointmentQueriesHandler;
            this.addAppointmentCommandHandler = addAppointmentCommandHandler;
            this.deleteAppointmentCommandHandler = deleteAppointmentCommandHandler;
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            return await appointmentQueriesHandler.GetAllAsync();
        }


        [HttpPost("AddAppointment")]
        public void AddExaminationRoom([FromBody] AddAppointmentCommand appointmentCommand)
        {
            addAppointmentCommandHandler.Handle(appointmentCommand);
        }

        [HttpGet("GetAllDoctorAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAllDoctorAppointmentsAsync(int idDoctor)
        {
            return await appointmentQueriesHandler.GetAllDoctorAppointmentsAsync(idDoctor);
        }

        [HttpGet("GetAllTodaysDoctorAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetTodaysDoctorAppointmentsAsync(int idDoctor)
        {
            return await appointmentQueriesHandler.GetTodaysDoctorAppointmentsAsync(idDoctor);
        }


        [HttpGet("GetClosestPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetClosestAppointmentsAsync(int idPatient)
        {
            return await appointmentQueriesHandler.GetClosestAppointmentsAsync(idPatient);
        }


        [HttpGet("GetAllPatientAppointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAllPatientAppointmentsAsync(int idPatient)
        {
            return await appointmentQueriesHandler.GetAllPatientAppointmentsAsync(idPatient);
        }


        [HttpDelete("DeleteAppointment")]
        public void DeleteAppointment([FromQuery] DeleteAppointmentCommand deleteAppointmentCommand)
        {
            deleteAppointmentCommandHandler.Handle(deleteAppointmentCommand);
        }
    }
}

