namespace Patient.Web.Application.DataServiceClients
{
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAppointmentServiceClient
    {
        Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointmentsAsync(int idPatient);
        Task<IEnumerable<AppointmentDto>> GetAllPatientAppointmentsAsync(int idPatient);
        Task AddAppointmentAsync(AppointmentDto appointmentdto);
        Task DeleteAppointmentAsync(int Id);

    }
}
