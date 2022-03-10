namespace DoctorApp.Application.Model
{
    using DoctorApp.Application.Model.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Popups;

    public partial class Model : IOperations
    {
        public void LoadMedicalAppointmentsList()
        {
            Task.Run(() => this.LoadMedicalAppointmentsTask());
        }

        private void LoadMedicalAppointmentsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                MedicalAppointmentData[] appointments = networkClient.GetMedicalAppointments(this.IdDoctor);

                this.AppointmentList = appointments.ToList();
            }
            catch (Exception)
            {
            }
        }

        public void AddPrescriptionObject()
        {
            Task.Run(() => this.AddPrescriptionObjectTask());
        }

        private void AddPrescriptionObjectTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                networkClient.AddPrescriptionPost(this.IdDoctor ,this.PatId, this.ExpireDate, this.Lek1, this.Lek2, this.Dawka1, this.Dawka2);
            }
            catch (Exception)
            {
            }
        }

        public void LoadTodaysMedicalAppointmentsList()
        {
            Task.Run(() => this.LoadTodaysMedicalAppointmentsTask());
        }

        private void LoadTodaysMedicalAppointmentsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                MedicalAppointmentData[] appointments = networkClient.GetTodaysMedicalAppointments(this.IdDoctor);

                this.AppointmentList = appointments.ToList();
            }
            catch (Exception)
            {
            }
        }

        public void LoadPrescriptionList() 
        {
            Task.Run(() => this.LoadPrescriptionTask());
        }

        private void LoadPrescriptionTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                PrescriptionData[] prescription = networkClient.GetPrescriptions(this.IdDoctor);

                this.PrescriptionList = prescription.ToList();
            }
            catch (Exception)
            {
            }
        }
    }
}
