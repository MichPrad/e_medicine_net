namespace Doctor.Application.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Windows.Input;

    public partial class Controller : IController
    {

        public ICommand GetDoctorAppointmentsCommand { get; private set; }

        public ICommand GetTodaysDoctorAppointmentsCommand { get; private set; }

        public ICommand GetAllDoctorPrescriptionsCommand { get; private set; }

        public ICommand AddPrescriptionCommand { get; private set; }

        public ICommand DeletePrescriptionCommand { get; private set; }

        public ICommand DeleteAppointmentCommand { get; private set; }

        public async Task AddPrescriptionAsync()
        {
            await Task.Run(() => this.AddPrescription());
        }
        public async Task GetDoctorAppointmentsAsync()
        {
            await Task.Run(() => this.GetDoctorAppointments());
        }
        public async Task GetTodaysDoctorAppointmentsAsync()
        {
            await Task.Run(() => this.GetTodaysDoctorAppointments());
        }
        public async Task GetAllDoctorPrescriptionsAsync()
        {
            await Task.Run(() => this.GetAllDoctorPrescriptions());
        }
        public async Task DeletePrescriptionAsync()
        {
            await Task.Run(() => this.DeletePrescription());
        }

        public async Task DeleteAppointmentAsync()
        {
            await Task.Run(() => this.DeleteAppointment());
        }

        private void DeletePrescription()
        {
            this.Model.DeletePrescription();
        }
        private void DeleteAppointment()
        {
            this.Model.DeleteAppointment();
        }

        private void AddPrescription()
        {
            this.Model.AddPrescriptionObject();
        }

        private void GetDoctorAppointments()
        {
            this.Model.LoadMedicalAppointmentsList();
        }

        private void GetTodaysDoctorAppointments()
        {
            this.Model.LoadTodaysMedicalAppointmentsList();
        }

        private void GetAllDoctorPrescriptions()
        {
            this.Model.LoadPrescriptionList();
        }

    }
}
