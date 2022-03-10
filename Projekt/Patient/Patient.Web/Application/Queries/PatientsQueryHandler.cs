namespace Patient.Web.Application.Queries
{
    using Patient.Web.Application.DataServiceClients;
    using Patient.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class PatientsQueryHandler : IPatientsHandler
    {
        private readonly IPrescriptionServiceClient prescriptionServiceClient;
        private readonly IAppointmentServiceClient appointmentServiceClient;

        public PatientsQueryHandler() { }

        public PatientsQueryHandler(IPrescriptionServiceClient prescriptionServiceClient, IAppointmentServiceClient appointmentServiceClient)
        {
            this.prescriptionServiceClient = prescriptionServiceClient;
            this.appointmentServiceClient = appointmentServiceClient;
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllPatientPrescriptionAsync(int idPatient)
        {
            var doctors = await prescriptionServiceClient.GetAllPatientPrescriptionsAsync(idPatient);

            return doctors;

        }

        public async Task<IEnumerable<AppointmentDto>> GetAllPatientAppointmentsAsync(int idPatient)
        {
            var allAppointments = await appointmentServiceClient.GetAllPatientAppointmentsAsync(idPatient);

            return allAppointments;

        }

        public async Task<IEnumerable<AppointmentDto>> GetClosestPatientAppointmentsAsync(int idPatient)
        {
            var closestAppointments = await appointmentServiceClient.GetClosestPatientAppointmentsAsync(idPatient);

            return closestAppointments;

        }

        public IEnumerable<AppointmentDto> GetAppoinmentsByPlace(IEnumerable<AppointmentDto> listOfAppointments, string place) 
        {
            IEnumerable<AppointmentDto> list = listOfAppointments.Where(app => app.Place.Name.Equals(place));

            return list;
        }

        public IEnumerable<PrescriptionDto> GetPrescriptionsByYearOfExpiration(IEnumerable<PrescriptionDto> listOfPrescriptions, int year) 
        {
            IEnumerable<PrescriptionDto> list = listOfPrescriptions.Where(pres => pres.DateOfExpiration.Year == year);

            return list;
        }

        public async Task AddAppointmentAsync(AppointmentDto appointmentDto)
        {
            await appointmentServiceClient.AddAppointmentAsync(appointmentDto);

        }

        public async Task DeleteAppointmentAsync(int Id)
        {
            await appointmentServiceClient.DeleteAppointmentAsync(Id);
        }
    }
}
