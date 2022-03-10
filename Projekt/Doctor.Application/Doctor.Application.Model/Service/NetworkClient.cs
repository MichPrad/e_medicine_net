namespace Doctor.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Net.Http;
    using Doctor.Application.Model.Data;
    using Doctor.Application.Model;
    using System.Text.Json;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public MedicalAppointmentData[] GetMedicalAppointments(int IdDoctor)
        {
            string callUri = String.Format("get-all-doctor-appointments?idDoctor={0}", IdDoctor.ToString());

            MedicalAppointmentData[] appointments = this.serviceClient.CallWebService<MedicalAppointmentData[]>(HttpMethod.Get, callUri);

            return appointments;
        }

        public MedicalAppointmentData[] GetTodaysMedicalAppointments(int IdDoctor)
        {
            string callUri = String.Format("get-allTodays-doctor-appointments?idDoctor={0}", IdDoctor.ToString());

            MedicalAppointmentData[] appointments = this.serviceClient.CallWebService<MedicalAppointmentData[]>(HttpMethod.Get, callUri);

            return appointments;
        }

        public PrescriptionData[] GetPrescriptions(int IdDoctor)
        {
            string callUri = String.Format("get-all-doctor-prescriptions?idDoctor={0}", IdDoctor.ToString());

            PrescriptionData[] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>(HttpMethod.Get, callUri);

            return prescriptions;
        }

        public void AddPrescriptionPost(int IdDoctor,string IdPat, DateTime expire, string lek1, string lek2, string dawka1, string dawka2)
        {
            string callUri = String.Format("add-new-prescription");

            try
            {
                AddPrescriptionData prescription = new AddPrescriptionData()
                {
                    IdDoctor = IdDoctor,
                    IdPatient = Convert.ToInt32(IdPat),
                    Date = DateTime.Now,
                    DateOfExpiration = expire,
                    Medicines = new Dictionary<string, int>() { { lek1, Convert.ToInt32(dawka1) }, { lek2, Convert.ToInt32(dawka2) } }
                };

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                string jsonString = JsonSerializer.Serialize(prescription, options);

                this.serviceClient.CallWebService(HttpMethod.Post, callUri, jsonString);
            }
            catch (Exception FormatException)
            {
            }

        }
        public async void DeleteAppointment(int id)
        {
            await this.serviceClient.DeleteAppointmentAsync(id);
        }

        public async void DeletePrescription(int id)
        {
            await this.serviceClient.DeletePrescriptionAsync(id);
        }
    }
}
